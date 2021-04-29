using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
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
	private int m_MagazineCapacity = 30;

	[FormerlySerializedAs("m_MaxAmmo")] [SerializeField]
	private int m_ReserveAmmo = 180;

	[SerializeField]
	private float m_RateOfFire = 0.25f;

	#endregion


	#region Internal Fields

	private int m_CurrentAmmo;

	private IEnumerator m_ShootCoroutine; // Variable the datatype (delegate)

	#endregion


	#region Internal Properties

	private int CurrentAmmo {
		get => m_CurrentAmmo;
		set {
			m_CurrentAmmo = value;
			m_AmmoCounter.text = $"{m_CurrentAmmo} / {m_ReserveAmmo}";
		}
	}

	#endregion


	#region Monobehaviour Methods

	private void Awake() {
		CurrentAmmo = m_MagazineCapacity;
	}

	#endregion


	// A helper wrapper function so external
	// classes don't need to know about he coroutine
	public void Shoot() {
		if (m_ShootCoroutine == null) {
			m_ShootCoroutine = ShootCoroutine(); // Storing the function in variable
			StartCoroutine(m_ShootCoroutine);
		}
	}

	
	private IEnumerator ShootCoroutine() {
		if (this.CurrentAmmo > 0) {
			Instantiate(m_ProjectilePrefab.gameObject,
				m_SpawnPosition.position,
				m_SpawnPosition.rotation);
			this.CurrentAmmo--;
		}

		if (this.CurrentAmmo <= 0) {
			Reload();
		}

		yield return new WaitForSeconds(m_RateOfFire); // Waited for x amount of time

		m_ShootCoroutine = null;
	}

	public void Reload() {
		if (m_ReserveAmmo <= 0) {
			return; // Exiting
		}
		
		// Figure out how many bullets are need to top up the magazine.
		// max[12] - (magCap[6] - CA[3])
		var bulletsNeeded = m_MagazineCapacity - CurrentAmmo;

		if (bulletsNeeded <= m_ReserveAmmo) {
			m_ReserveAmmo -= bulletsNeeded;
			CurrentAmmo += bulletsNeeded;
		} else {
			CurrentAmmo += m_ReserveAmmo;
			m_ReserveAmmo = 0;
			CurrentAmmo = CurrentAmmo; // Update text
		}
	}
}