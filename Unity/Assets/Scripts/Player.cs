using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	[SerializeField]
	private Weapon m_Weapon = null;

	// Update is called once per frame
	void Update() {
		// Click left mouse button
		if (Input.GetMouseButtonDown(0)) {
			m_Weapon.Shoot();
		}
	}
}