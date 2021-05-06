using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {
	
	[SerializeField]
	private Projectile m_ProjectilePrefab = null;

	[SerializeField]
	private Transform m_SpawnPosition = null;

	// This is a public method that can be accessed outside of the class
	// In this example the Player.cs class is calling the method
	/// <summary>
	/// Fire a projectile
	/// </summary>
	public void Shoot() {
		Instantiate(m_ProjectilePrefab.gameObject, 
					m_SpawnPosition.position,
					m_SpawnPosition.rotation);
	}

	private void Reload() {
		
	}

	/* SHOOT
		* Needs bullets
			* If there are no bullets RELOAD
	 */
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{

	[SerializeField]
	private Projectile m_ProjectilePrefab = null;

	[SerializeField]
	private Transform m_SpawnPosition = null;

	// This is a public method that can be accessed outside of the class
	// In this example the Player.cs class is calling the method
	/// <summary>
	/// Fire a projectile
	/// </summary>
	public void Shoot()
	{
		Instantiate(m_ProjectilePrefab.gameObject,
					m_SpawnPosition.position,
					m_SpawnPosition.rotation);
	}

	private void Reload()
	{

	}

	/* SHOOT
		* Needs bullets
			* If there are no bullets RELOAD
	 */
}
