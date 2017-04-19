using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatureTracking : MonoBehaviour {

	[SerializeField]
	private Transform target;

	public Vector3 TargetPosition
	{
		get {
			return target.position;
		}
	}


	void Start () {
		
	}
	
	void Update () {
		
	}
}
