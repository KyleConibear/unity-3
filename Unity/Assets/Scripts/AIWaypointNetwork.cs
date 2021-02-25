using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// An enum is a special "class" that represents a group of constants
// Constants are immutable (cannot  be changed) values which are known at compile time and do not change for the life of the program
// We are using an enum to describe 3 different modes of displaying a connection between waypoints
// e.g. None, Connection(straight line), Paths(nav mesh path)
public enum PathDisplayMode {
	None = 0,
	Connections = 1,
	Paths = 2
}

public class AIWaypointNetwork : MonoBehaviour {
	// A field is a member variable
	// member means belonging to the class (AIWaypointNetwork)
	// it is best practice to keep your fields private
	// that way no one outside of the class can access them


	#region SerializeFields

	// A list is a collection (container) of a data type
	// the 'm_' prefix stands for member variable 
	[SerializeField] // [Attribute] -> SerializeFields make a private variable visible in the inspector
	private List<Transform> m_Waypoints = new List<Transform>();

	#endregion


	#region Internal Field
	
	// A field of type PathDisplayMode the enum defined above which contains which type we will be using at run time
	private PathDisplayMode m_DisplayMode = PathDisplayMode.Connections;
	
	// The start of the path to be drawn stored as an index of "m_Waypoints"
	private int m_UIStart = 0;
	
	// The end of the path to be drawn stored as an index of "m_Waypoints"
	private int m_UIEnd = 0;

	#endregion

	// A property exposes a field
	#region Properties

	public PathDisplayMode DisplayMode {
		get { // A getter returns a value
			return m_DisplayMode;
		}
		set { m_DisplayMode = value; }
	}

	public int UIStart { get; set; }

	public int UIEnd { get; set; }

	public List<Transform> Waypoints { get { return m_Waypoints; } }

	#endregion
}