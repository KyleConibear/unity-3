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


	#region MyRegion

	[SerializeField] // [Attribute] -> SerializeFields make a private variable visible in the inspector
	private AIWaypointNetwork m_AiWaypointNetwork;

	#endregion

	
	
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

	// Where to ?
	// Check if target destination is unreachable
	// When we have arrived
	

	#region Internal Methods

	private void SetNextDestination(bool incremet) {
		
	}

	#endregion
}