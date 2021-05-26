// Step 1
using UnityEngine;
using UnityEngine.AI;

// Step 2
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(NavAgentRootMotion))]
[RequireComponent(typeof(Health))]
public class NonPlayerCharacter : MonoBehaviour
{
	#region Private Fields
// Step 3
	private Animator m_Animator;
	private NavMeshAgent m_NavMeshAgent;
	private NavAgentRootMotion m_NavAgentRootMotion;
	private Health m_Health;

	#endregion


	#region MonoBehaviour Methods

	private void Awake() {
		// Step 4
		m_Animator = this.GetComponent<Animator>();
		m_Health = this.GetComponent<Health>();
		m_NavMeshAgent = this.GetComponent<NavMeshAgent>();
		m_NavAgentRootMotion = this.GetComponent<NavAgentRootMotion>();
		m_Health.OnDead += Death; // Assigning our Death method to our health OnDead action
	}

	#endregion


	#region Private Methods

	private void Death() {
		// Step 5
		m_Animator.enabled = false;
		m_NavMeshAgent.enabled = false;
		m_NavAgentRootMotion.enabled = false;
	}

	#endregion
}
