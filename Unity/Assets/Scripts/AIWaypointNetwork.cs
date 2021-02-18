using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIWaypointNetwork : MonoBehaviour
{
	// A field is a member variable
	// member means belonging to the class (AIWaypointNetwork)
	// it is best practice to keep your fields private
	// that way no one outside of the class can access them
	#region Fields

	// A list is a collection (container) of a data type
	// the 'm_' prefix stands for member variable 
	[SerializeField] // [Attribute] -> SerializeFields make a private variable visible in the inspector
	private List<Transform> m_Waypoints = new List<Transform>();

	#endregion
}
