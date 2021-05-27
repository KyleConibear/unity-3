using System;
using UnityEngine;
// Step 1
using UnityEngine.UI;


/// <summary>
/// The Health class represents how much health an object has
/// </summary>

public class Health : MonoBehaviour {
	
	#region SerializeField Fields

	[SerializeField]
	private int m_MaxHealth = 100;

	[SerializeField]
	private int m_CurrentHealth;
	
	// Step 2
	[SerializeField]
	private Image m_HealthImage;

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

		if (m_HealthImage) {
			m_HealthImage.fillAmount = (float) m_CurrentHealth / m_MaxHealth;
		}

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