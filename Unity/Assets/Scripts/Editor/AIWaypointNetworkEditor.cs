using System;
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

	// Implementing this function means the Unity Editor will call it when
	// the Scene View is being repainted. This gives us a hook to do our
	// own rendering to the scene view
	void OnSceneGUI() {
		// Get reference to selected component
		AIWaypointNetwork network = (AIWaypointNetwork) target;
		
		// Fetch all waypoints from the network and render a label for each one
		for (int i = 0; i < network.Waypoints.Count; i++) {
			if (network.Waypoints[i] != null) {
				Handles.Label(network.Waypoints[i].position, $"Waypoint {i}");
			}
		}
		
		// If we are in the connections mode then we will draw lines connecting the waypoints
		if (network.DisplayMode == PathDisplayMode.Connections) {
			// Allocate array of vector to store the polyline position
			Vector3[] linePoints = new Vector3[network.Waypoints.Count + 1];
			
			// Loop through each waypoint + one additional interation
			for (int i = 0; i <= network.Waypoints.Count; i++) {
				// Calculate the waypoint index with wrap-round in the last iteration
				int index = i;
				if (index == network.Waypoints.Count) {
					index = 0;
				}
				
				// Fetch the position of the waypoint for this iteration and copy into our vector array.
				if (network.Waypoints[index] != null) {
					linePoints[i] = network.Waypoints[index].position;
				} else {
					linePoints[i] = Vector3.positiveInfinity;
				}
			}
			
			// Set the Handle color to Cyan
			Handles.color = Color.cyan;
			
			// Render the ployline in the scene view by passing in our list of waypoints positions
			Handles.DrawPolyLine(linePoints);
		}
	}
}