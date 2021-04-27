using UnityEngine;
using UnityEngine.UI; // Add this library

public class Weapon : MonoBehaviour {
	
	#region Internal SerializeFields

	[SerializeField]
	private Projectile m_ProjectilePrefab = null;

	[SerializeField]
	private Transform m_SpawnPosition = null;

	[SerializeField]
	private Text m_AmmoCounter;
	
	[SerializeField]
	private int m_MaxAmmo = 30;

	#endregion


	#region Internal Fields

	private int m_CurrentAmmo;

	#endregion


	#region Internal Properties
	private int CurrentAmmo {
		get => m_CurrentAmmo;
		set {
			m_CurrentAmmo = value;
			m_AmmoCounter.text = $"{m_CurrentAmmo} / {m_MaxAmmo}";
		}
	}

	#endregion

	#region Monobehaviour Methods
	private void Awake() {
		CurrentAmmo = m_MaxAmmo;
	}

	#endregion
	
	// This is a public method that can be accessed outside of the class
	// In this example the Player.cs class is calling the method
	/// <summary>
	/// Fire a projectile
	/// </summary>
	public void Shoot() {
		if (this.CurrentAmmo > 0) {
			Instantiate(m_ProjectilePrefab.gameObject,
				m_SpawnPosition.position,
				m_SpawnPosition.rotation);
			this.CurrentAmmo--;
		}
	}

	private void Reload() {
	}

	/* SHOOT
		* Needs bullets
			* If there are no bullets RELOAD
	 */
}