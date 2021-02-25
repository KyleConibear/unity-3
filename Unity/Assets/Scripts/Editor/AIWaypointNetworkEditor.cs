using UnityEngine;
using System.Collections;
using UnityEditor;
using UnityEngine.AI;


/// <summary>
/// Custom Inspector and Scene View Rendering for the AIWaypointNetwork Component
/// </summary>
[CustomEditor(typeof(AIWaypointNetwork))]
public class AIWaypointNetworkEditor : Editor {
	// Called by Unity Editor when the Inspector needs repainting for an
	// AIWaypointNetwork Component
	public override void OnInspectorGUI() {
		// Get reference to selected component
		AIWaypointNetwork network = (AIWaypointNetwork) target;

		// Show the Display Mode Enumeration (enum) Selector
		network.DisplayMode = (PathDisplayMode) EditorGUILayout.EnumPopup("Display Mode", network.DisplayMode);

		// If we are in Paths display mode then display the integer sliders for the Start and End waypoint indices (indexes)
		if (network.DisplayMode == PathDisplayMode.Paths) {
			network.UIStart =
				EditorGUILayout.IntSlider("Waypoint Start", network.UIStart, 0, network.Waypoints.Count - 1);
			network.UIEnd = EditorGUILayout.IntSlider("Waypoint End", network.UIEnd, 0, network.Waypoints.Count - 1);
		}

		// Tell Unity to do its default drawing of all serialized members that are NOT hidden in the inspector
		DrawDefaultInspector();
	}
}