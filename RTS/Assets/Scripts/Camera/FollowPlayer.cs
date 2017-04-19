using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour {

	public Transform target;
	public float allowedVariance;
	public float returnFactor;

	private Vector3 desiredOffset;
	private Vector3 currentOffset;
	private Vector3 desiredPosition;
	private float curDistance;

	void Start()
	{
		desiredOffset = transform.position - target.position;
	}

	void Update () 
	{
		currentOffset = transform.position -  target.position;

		curDistance = Vector3.Distance (currentOffset, desiredOffset);
		if (curDistance > allowedVariance)
		{
			desiredPosition = target.position + desiredOffset;
			transform.position = Vector3.MoveTowards (transform.position, desiredPosition, returnFactor * Time.deltaTime * curDistance);
		}
	}
}
