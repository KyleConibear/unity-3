using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Health))]
public class NonPlayerCharacter : MonoBehaviour
{
	#region Private Fields

	private Health m_Health;

	#endregion


	#region MonoBehaviour Methods

	private void Awake() {
		m_Health = this.GetComponent<Health>();
		m_Health.OnDead += Death; // Assigning our Death method to our health OnDead action
	}

	#endregion


	#region Private Methods

	private void Death() {
		// Temporary, will be replaced with ragdoll
		Destroy(this.gameObject);
	}

	#endregion
}
