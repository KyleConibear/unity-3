using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public enum NavigationType {
	Waypoint,
	Wander
}

[RequireComponent(typeof(NavMeshAgent))]
public class NavAgent : MonoBehaviour {
	#region Internal Fields

	// The components DateType is NavMeshAgent
	private NavMeshAgent m_NavMeshAgent = null; // Provides use with a reference to the component, this allows us to communicate with it

	private int m_NavPositionIndex = 0; 

	private float m_SmoothAngle = 0;

	#endregion


	#region SerializeFields

	[SerializeField]
	private Animator m_Animator = null;
	
	[SerializeField] // [Attribute] -> SerializeFields make a private variable visible in the inspector
	private AIWaypointNetwork m_AiWaypointNetwork;

	[SerializeField]
	private NavigationType m_NavType = NavigationType.Wander;

	#endregion


	#region MonoBehaviour

	// Start is called before the first frame update
	// Start is used for initialization
	private void Start() {
		// Initialization is the first time we assign a value to a new variable/field
		m_NavMeshAgent = GetComponent<NavMeshAgent>(); // Finds a Component of the given Type on the same Gameobject as the script

		m_NavMeshAgent.updateRotation = false;
		
		this.MoveToPosition(this.GetDestinationPosition());
	}

	// Update is called once per frame
	private void Update() {

		// Transform agents target velocity into local space
		Vector3 targetVelocity = transform.InverseTransformVector(m_NavMeshAgent.desiredVelocity);

		// Speed is simply the amount of desired velocity projected onto our own forward vector
		float speed = Mathf.Abs(targetVelocity.z);
		
		// Get angle in degrees we need to turn to reach the desired velocity direction
		float targetAngle = Mathf.Atan2(targetVelocity.x, targetVelocity.z) * Mathf.Rad2Deg;
		
		// Smoothly interpolate towards the new angle
		m_SmoothAngle = Mathf.MoveTowardsAngle(m_SmoothAngle, targetAngle, 80f * Time.deltaTime);
		
		// Set animator parameters
		m_Animator.SetFloat("Speed", speed, 0.1f, Time.deltaTime);
		m_Animator.SetFloat("Angle", m_SmoothAngle);


		if (m_NavMeshAgent.desiredVelocity.sqrMagnitude > Mathf.Epsilon) {
			if (Mathf.Abs(targetAngle) < 80.0f && m_Animator.GetCurrentAnimatorStateInfo(0).IsName("Base Layer.Locomotion")) {
				Quaternion lookRotation = Quaternion.LookRotation(m_NavMeshAgent.desiredVelocity, Vector3.up);
				transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, 5.0f * Time.deltaTime);
			}
		}
		
		if ((!m_NavMeshAgent.hasPath &&
		     !m_NavMeshAgent.pathPending) ||
		    m_NavMeshAgent.pathStatus == NavMeshPathStatus.PathInvalid) {
			Debug.Log("Has reached destination");

			// Increment the NavPositionIndex to go to the
			// next position in our AIWaypointNetwork
			m_NavPositionIndex++;
			// Go to next destination
			this.MoveToPosition(this.GetDestinationPosition());

			// Do nothing
		} else { // Go to a new destination
			if (!m_NavMeshAgent.isPathStale) {
			}
		}
	}

	private void OnAnimatorMove() {
		if (m_Animator.GetCurrentAnimatorStateInfo(0).IsName("Base Layer.Locomotion")) {
			transform.rotation = m_Animator.rootRotation;
			
			m_NavMeshAgent.velocity = m_Animator.deltaPosition / Time.deltaTime;
		}
	}

	#endregion


	// Where to ?
	// Check if target destination is unreachable
	// When we have arrived


	#region Internal Methods

	/// <summary>
	/// Move the nav mesh agent to the provided position
	/// </summary>
	/// <param name="position">target position</param>
	private void MoveToPosition(Vector3 position) {
		if (m_NavMeshAgent == null)
			return;
		m_NavMeshAgent.destination = position;
	}

	private Vector3 GetDestinationPosition() {
		if (m_AiWaypointNetwork == null)
			return Vector3.zero;

		switch (m_NavType) {
			case NavigationType.Waypoint:
				if (m_NavPositionIndex > m_AiWaypointNetwork.Waypoints.Count - 1) {
					m_NavPositionIndex = 0;
				}

				return m_AiWaypointNetwork.Waypoints[m_NavPositionIndex].position;
			default:
				var range = 20;
				Vector3 randomDirection = Random.insideUnitSphere * range;
				randomDirection += transform.position;
				NavMeshHit hit;
				NavMesh.SamplePosition(randomDirection, out hit, range, 1);
				return hit.position;
		}
	}

	#endregion
}