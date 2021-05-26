using System;
using UnityEngine;

/// <summary>
/// The Health class represents how much health an object has
/// </summary>

public class Health : MonoBehaviour {
	
	
	
	#region SerializeField Fields

	[SerializeField]
	private int m_MaxHealth = 100;

	[SerializeField]
	private int m_CurrentHealth;

	#endregion


	#region Public Properties

	/// <summary>
	/// If CurrentHealth is greater than 0 we are alive
	/// </summary>
	public bool IsAlive => m_CurrentHealth > 0;

	// Is delegate which is a variable types that hold a function
	public System.Action OnDead { get; set; }

	#endregion
	

	#region MonoBehaviour Methods

	private void Reset() {
		m_CurrentHealth = m_MaxHealth;
	}

	private void Start() {
		Reset();
	}

	#endregion


	#region Public Methods

	public void Damage(int value) {
		Debug.Log($"{this.name} {value} damage taken");
		
		// Subtract damage value from our current health
		m_CurrentHealth -= value;

		if (this.IsAlive == false) { // We are dead
			// Do something when we die
			// The `?` is a null check
			OnDead?.Invoke(); // Call the delegate function (could be anything)
		}
	}

	public void Heal(int value) {
		// Add heal value to our current health
		m_CurrentHealth += value;
	}

	#endregion
}