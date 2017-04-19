using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseTracking : MonoBehaviour {

	public LayerMask layerMask;
	public float distance = 20;

	private Vector3 cachedHitPosition;
	private Transform cachedHitObject;
	private Vector3 cachedHitNormal;
	public float cacheDuration = .01f;
	private float cacheExpireTime;

	public Vector3 HitPosition
	{
		get {
			if (Time.time < cacheExpireTime)
				return cachedHitPosition;

			PerformRaycast ();
			return cachedHitPosition;
		}
	}

	public Transform HitObject
	{
		get {
			if (Time.time < cacheExpireTime)
				return cachedHitObject;

			PerformRaycast ();
			return cachedHitObject;
		}
	}

	public Vector3 HitNormal
	{
		get {
			if (Time.time < cacheExpireTime)
				return cachedHitNormal;

			PerformRaycast ();
			return cachedHitNormal;
		}
	}

	private void PerformRaycast()
	{
		Ray raycast = Camera.main.ScreenPointToRay (Input.mousePosition);
		RaycastHit hit;

		if(Physics.Raycast(raycast, out hit, distance, layerMask))
		{
			cacheExpireTime = Time.time + cacheDuration;
			cachedHitPosition = hit.point;
			cachedHitObject = hit.collider.gameObject.transform;
			cachedHitNormal = hit.normal;
		}
	}
}
