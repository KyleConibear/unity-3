using System;
using System.Diagnostics;
using UnityEngine;
// Step 1
using UnityEngine.UI;
using Debug = UnityEngine.Debug;


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
	public System.Action DamageAction { get; set; } // Step 1
	public System.Action DeadAction { get; set; }

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
		// Subtract damage value from our current health
		m_CurrentHealth -= value;

		Debug.Log($"{name}>Health.Damage: value<{value}>, health<{m_CurrentHealth}>, isAlive<{IsAlive}>");

		if (m_HealthImage) {
			m_HealthImage.fillAmount = (float) m_CurrentHealth / m_MaxHealth;
		}

		if (this.IsAlive == false) { // We are dead
			Debug.Log($"{name}>Health.Damage: Is DEAD");
			// Fix health bar remaining after death
			m_HealthImage.enabled = false;

			// Do something when we die
			// The `?` is a null check
			DeadAction?.Invoke(); // Call the delegate function (could be anything)
		} 
		else { // Step 2
			DamageAction?.Invoke();
		}
	}

	public void Heal(int value) {
		// Add heal value to our current health
		m_CurrentHealth += value;
	}

	#endregion
}