using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CreatureTracking))]
public class CreatureMovement : MonoBehaviour {

	private CreatureTracking creatureTracking;

	public Vector3 targetPosition;

	public float walkSpeed = 2;
	private Animator animator;

	public float turnSmoothTime = 0.2f;
	public float turnSmoothVelocity;

	public float speedSmoothTime = 0.1f;
	private float speedSmoothVelocity;
	private float currentSpeed;

	public float gravity = -12;
	public float yVelocity;
	public float stoppingDistance = 1;

	CharacterController controller;

	void Start () 
	{
		creatureTracking = GetComponent<CreatureTracking>();

		animator = GetComponent<Animator> ();
		controller = GetComponent<CharacterController> ();

		targetPosition = transform.position;
	}

	void Update () 
	{
		targetPosition = creatureTracking.TargetPosition;

		HandleMovementAndRotation ();
	}

	void HandleMovementAndRotation()
	{
		float distance = Vector3.Distance (transform.position, targetPosition);

		Vector2 input = new Vector2 (targetPosition.x - transform.position.x, targetPosition.z - transform.position.z);
		Vector2 inputDirection = input.normalized;

		if (distance < stoppingDistance)
		{
			inputDirection = Vector2.zero;
		}

		if (inputDirection != Vector2.zero)
		{
			float targetRotation = Mathf.Atan2 (inputDirection.x, inputDirection.y) * Mathf.Rad2Deg;
			transform.eulerAngles = Vector3.up * Mathf.SmoothDampAngle (transform.eulerAngles.y, targetRotation, ref turnSmoothVelocity, turnSmoothTime);
		}

		float targetSpeed = inputDirection.magnitude * walkSpeed;
		currentSpeed = Mathf.SmoothDamp (currentSpeed, targetSpeed, ref speedSmoothVelocity, speedSmoothTime);

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
