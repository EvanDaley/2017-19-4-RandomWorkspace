using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMovement : MonoBehaviour {

	public float walkSpeed = 2;
	private Animator animator;

	public float turnSmoothTime = 0.2f;
	public float turnSmoothVelocity;

	public float speedSmoothTime = 0.1f;
	private float speedSmoothVelocity;
	private float currentSpeed;

	public float gravity = -12;
	public float yVelocity;

	CharacterController controller;

	void Start () {
		animator = GetComponent<Animator> ();
		controller = GetComponent<CharacterController> ();
	}
	
	void Update () 
	{
		Vector2 input = new Vector2 (Input.GetAxisRaw ("Horizontal"), Input.GetAxisRaw ("Vertical"));
		Vector2 inputDirection = input.normalized;

		if (inputDirection != Vector2.zero)
		{
			float targetRotation = Mathf.Atan2 (inputDirection.x, inputDirection.y) * Mathf.Rad2Deg;
			transform.eulerAngles = Vector3.up * Mathf.SmoothDampAngle (transform.eulerAngles.y, targetRotation, ref turnSmoothVelocity, turnSmoothTime);
		}

		float targetSpeed = inputDirection.magnitude * walkSpeed;
		currentSpeed = Mathf.SmoothDamp (currentSpeed, targetSpeed, ref speedSmoothVelocity, speedSmoothTime);
		//transform.Translate (transform.forward * currentSpeed * Time.deltaTime, Space.World);

		yVelocity += Time.deltaTime * gravity;
		Vector3 velocity = transform.forward * currentSpeed + Vector3.up * yVelocity;
		controller.Move (velocity * Time.deltaTime);

		if (controller.isGrounded)
		{
			yVelocity = 0;
		}

		float animationSpeedPercent = inputDirection.magnitude;
		animator.SetFloat ("SpeedPercent", animationSpeedPercent, speedSmoothTime, Time.deltaTime);


	}
}
