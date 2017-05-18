using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightFlicker : MonoBehaviour {

	public float flickerLength = .1f;
	public float lightCooldown;
	public float onOffRatio = 2f;

	public Light myLight;

	void Update () 
	{
		if (Time.time > lightCooldown)
		{
			Toggle ();

			lightCooldown = Random.value * flickerLength;

			if (myLight.enabled)
				lightCooldown *= onOffRatio;

			lightCooldown += Time.time;
		}
	}

	void Toggle()
	{
		print ("Toggling");
		myLight.enabled = !myLight.enabled;
	}
}
