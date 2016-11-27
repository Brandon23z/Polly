using UnityEngine;
using System.Collections;

public class CharcaterMove : MonoBehaviour {

		public float speed = 15.7F;
		public float jumpSpeed = 15.0F;
	public float gravity = 20.0F;
		private Vector3 moveDirection = Vector3.zero;
		void Update() {
			CharacterController controller = GetComponent<CharacterController>();
			if (controller.isGrounded) {
				moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
				moveDirection = transform.TransformDirection(moveDirection);
				moveDirection *= speed;
				if (Input.GetButton("Jump"))
					moveDirection.y = jumpSpeed;

			}
			moveDirection.y -= gravity * Time.deltaTime;
			controller.Move(moveDirection * Time.deltaTime);
		}

}
