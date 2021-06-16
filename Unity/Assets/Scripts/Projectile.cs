using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Projectile : MonoBehaviour {

	#region SerializeFields

	[SerializeField]
	private int m_Velocity = 10;

	[SerializeField]
	[Range(1,5)]
	[Tooltip("The amount of time in seconds before the Projectile is automatically destroyed")]
	private float m_LifeDuration = 3.5f;

	#endregion
	
	#region Internal Fields

	// Declare variable to hold a reference
	// to the RigidBody component
	private Rigidbody m_Rigidbody;

	private int m_Damage;
	
	#endregion


	// The purpose of a property to expose a private variable(field) outside of the class via public property
	#region Public Properties
	public int Damage {
		get => m_Damage;
		set => m_Damage = value;
	}

	#endregion


	#region MonoBehaviour Methods

	private void Awake() {
		// Initialize the Rigidbody variable
		// It is now ready to be used
		m_Rigidbody = GetComponent<Rigidbody>();
	}

	private void Start() {
		StartCoroutine(DestroySelf());
	}

	private void FixedUpdate() {
		this.ApplyVelocity();
	}

	private void OnCollisionEnter(Collision other) {
		if (other.gameObject.GetComponent<Projectile>()) {
			return; // Exit function
		} 
		
		Debug.Log($"{this.name} collided with {other.gameObject.name}");
		
		// Check whether the other object we are colliding with (NPC) has
		// a Health component attached
		// If the first operation equal null, perform the second operation
		var health = other.gameObject.GetComponent<Health>() ?? other.gameObject.GetComponentInParent<Health>();

		if (health != null) {
			// If the GameObject we are collider with is tagged as being a head, we apply twice as much damage
			// Syntax
			// condition ? true code : false code
			health.Damage(other.gameObject.CompareTag("Head") ? this.Damage * 2 : this.Damage);
		}
		Destroy(this.gameObject);
	}

	#endregion


	#region Internal Methods

	private void ApplyVelocity() {
		m_Rigidbody.AddRelativeForce(Vector3.forward * m_Velocity, ForceMode.VelocityChange);
	}

	private IEnumerator DestroySelf() {
		yield return new WaitForSeconds(m_LifeDuration); // Wait x amount of time
		Destroy(this.gameObject);
	}

	#endregion
}