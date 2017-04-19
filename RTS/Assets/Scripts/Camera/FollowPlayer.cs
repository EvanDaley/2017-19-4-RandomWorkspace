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

	public float minZoomScale = .5f;
	public float zoomScale = 1;
	public float maxZoomScale = 1.5f;

	void Start()
	{
		desiredOffset = transform.position - target.position;
	}

	void Update () 
	{

		if (Input.GetAxis ("Mouse ScrollWheel") > .1)
		{
			zoomScale -= .1f;
		}
		else 	if (Input.GetAxis ("Mouse ScrollWheel") <  -.1)
		{
			zoomScale += .1f;
		}

		zoomScale = Mathf.Clamp (zoomScale, minZoomScale, maxZoomScale);

		currentOffset = transform.position -  target.position;

		curDistance = Vector3.Distance (currentOffset, desiredOffset * zoomScale);
		if (curDistance > allowedVariance)
		{
			desiredPosition = target.position +  desiredOffset * zoomScale;
			transform.position = Vector3.MoveTowards (transform.position, desiredPosition, returnFactor * Time.deltaTime * curDistance);
		}
	}
}
