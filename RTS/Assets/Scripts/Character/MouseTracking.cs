using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseTracking : MonoBehaviour {

	public LayerMask layerMask;
	public float distance = 20;

	public Vector3 hitPosition;
	public Transform hitObject;
	public Vector3 hitNormal;

	void Update () 
	{
		Ray raycast = Camera.main.ScreenPointToRay (Input.mousePosition);
		RaycastHit hit;

		if(Physics.Raycast(raycast, out hit, distance, layerMask))
		{
			hitPosition = hit.point;
			hitObject = hit.collider.gameObject.transform;
			hitNormal = hit.normal;

			print (hitPosition);
		}
	}
}
