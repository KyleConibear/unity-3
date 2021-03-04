using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


[RequireComponent(typeof(NavMeshAgent))]
public class NavAgent : MonoBehaviour {
	#region Internal Fields

	// The components DateType is NavMeshAgent
	private NavMeshAgent m_NavMeshAgent = null; // Provides use with a reference to the component, this allows us to communicate with it 

	#endregion


	public AIWaypointNetwork m_AiWaypointNetwork;
	
	#region MonoBehaviour

	// Start is called before the first frame update
	// Start is used for initialization
	private void Start() {
		// Initialization is the first time we assign a value to a new variable/field
		m_NavMeshAgent = GetComponent<NavMeshAgent>(); // Finds a Component of the given Type on the same Gameobject as the script
	}

	// Update is called once per frame
	private void Update() {
	}

	#endregion


	#region Internal Methods

	private void SetNextDestination(bool incremet) {
		
	}

	#endregion
}