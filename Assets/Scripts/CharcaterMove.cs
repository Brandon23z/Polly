using UnityEngine;
using System.Collections;

public class CharcaterMove : MonoBehaviour {
	public float speed = 6.0F;
	public float jumpSpeed = 12.0F;
	public float gravity = 20.0F;
	public float lungeSpeed = 50.0F;

	private Vector3 moveDirection = Vector3.zero;
	void Update() {
		CharacterController controller = GetComponent<CharacterController>();

		if (controller.isGrounded)
		{	
			moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
			moveDirection = transform.TransformDirection(moveDirection);
			moveDirection = moveDirection * speed;
			if(Input.GetButton("Jump"))
			{
				moveDirection.y = jumpSpeed;
			}
		}

		else
		{
			Vector3 inputVector = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
			inputVector = transform.TransformDirection(inputVector);
			Vector2 clampedHorizontalVelocity = Vector2.ClampMagnitude(new Vector2(controller.velocity.x, controller.velocity.z), lungeSpeed);
			moveDirection = new Vector3(clampedHorizontalVelocity.x, controller.velocity.y, clampedHorizontalVelocity.y)  + (inputVector * Time.deltaTime * lungeSpeed);
		}

		moveDirection.y -= gravity * Time.deltaTime;
		controller.Move(moveDirection * Time.deltaTime);
	}
}