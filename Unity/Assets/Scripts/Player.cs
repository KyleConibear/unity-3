using UnityEngine;

public class Player : MonoBehaviour {

	#region Internal Fields

	private Weapon[] m_Weapons;
	private int m_WeaponIndex = 0;

	#endregion


	#region Internal Properties

	private Weapon Weapon => m_Weapons[m_WeaponIndex];

	#endregion


	#region MonoBehaviours

	private void Awake() {
		// This will find all of the weapon components
		// that are children of the Player GameObject
		m_Weapons = GetComponentsInChildren<Weapon>(true);
	}

	private void Start() {
		this.SelectWeapon(m_WeaponIndex);
	}

	private void Update() {
		// Click left mouse button
		if (Input.GetMouseButtonDown(0) || (this.Weapon.FireMode == Weapon.FireModeType.Full && Input.GetMouseButton(0))) {
			this.Weapon.Shoot();
		}
		
		// right click
		if (Input.GetMouseButton(1)) {
			this.SetFieldOfView(this.Weapon.ZoomAmount); // Step 3
		} else {
			this.SetFieldOfView(60);
		}

		if (Input.GetKeyDown(KeyCode.R)) {
			this.Weapon.Reload();
		}

		if (Input.GetKeyDown(KeyCode.Alpha1)) { // First weapon
			this.SelectWeapon(0);
		} else if (Input.GetKeyDown(KeyCode.Alpha2)) { // Second weapon
			this.SelectWeapon(1);
		} // Third weapon?
	}

	#endregion


	#region Internal Method

	private void SelectWeapon(int value) {
		if (value > -1 && value < m_Weapons.Length) {
			m_WeaponIndex = value;
			Weapon.gameObject.SetActive(true); // Enable selected weapon

			// Disable all weapons that are not selected
			for (int i = 0; i < m_Weapons.Length; i++) {
				if(i == value)
					continue; // (Skip) Break out of the current iteration
				m_Weapons[i].gameObject.SetActive(false);
			}
		}
	}
	private void SetFieldOfView(float value) {
		Camera.main.fieldOfView = value;
	}

	#endregion
}