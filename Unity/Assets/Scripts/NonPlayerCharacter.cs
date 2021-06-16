using System;
using UnityEngine;
using UnityEngine.AI;

public enum State {
	Patrol = 0,
	Chase = 1
}

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(NavAgentRootMotion))]
[RequireComponent(typeof(Health))]
public class NonPlayerCharacter : MonoBehaviour
{
	#region Private Fields

	// Components
	private Animator m_Animator;
	private NavMeshAgent m_NavMeshAgent;
	private NavAgentRootMotion m_NavAgentRootMotion;
	private Health m_Health;
	private Player m_Player; // Step 1
	
	// Data
	[SerializeField] private State m_State;
	private Vector3 m_LastKnownThreatPosition;
	
	#endregion


	#region MonoBehaviour Methods

	private void Awake() {
		m_Animator = this.GetComponent<Animator>();
		m_Health = this.GetComponent<Health>();
		m_NavMeshAgent = this.GetComponent<NavMeshAgent>();
		m_NavAgentRootMotion = this.GetComponent<NavAgentRootMotion>();
		m_Player = FindObjectOfType<Player>(); // Assuming there is only 1 player // Step 2
		m_Health.DamageAction += OnDamage;
		m_Health.DeadAction += OnDeath; // Assigning our OnDeath method to our health DeadAction action

		var rigidBodies = GetComponentsInChildren<Rigidbody>();
		foreach (var rigidBody in rigidBodies) {
			rigidBody.mass = 100;
		}
	}
	private void Start() {
		this.SetState(State.Patrol);
	}

	#endregion


	#region Private Methods

	private void OnDamage() {
		SetState(State.Chase);
	}
	private void SetState(State state) {
		m_State = state;
		switch (state) {
			case State.Patrol:
				m_NavAgentRootMotion.StartPatrolling();
				break;
			case State.Chase:
				m_NavAgentRootMotion.GoToPosition(m_Player.transform.position);
				break;
		}
	}
	
	private void OnDeath() {
		m_Animator.enabled = false;
		m_NavMeshAgent.enabled = false;
		m_NavAgentRootMotion.enabled = false;
	}

	#endregion
}
