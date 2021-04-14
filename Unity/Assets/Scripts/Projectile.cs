using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Projectile : MonoBehaviour {

	#region SerializeFields

	[SerializeField]
	private int m_Velocity = 10;

	#endregion
	
	#region Internal Fields

	// Declare variable to hold a reference
	// to the RigidBody component
	private Rigidbody m_Rigidbody;

	#endregion


	#region MonoBehaviour Methods

	private void Awake() {
		// Initialize the Rigidbody variable
		// It is now ready to be used
		m_Rigidbody = GetComponent<Rigidbody>();
	}

	private void FixedUpdate() {
		this.ApplyVelocity();
	}

	private void OnCollisionEnter(Collision other) {
		Destroy(this.gameObject);
	}

	#endregion


	#region Internal Methods

	private void ApplyVelocity() {
		m_Rigidbody.AddRelativeForce(Vector3.forward * m_Velocity, ForceMode.VelocityChange);
	}

	#endregion
}