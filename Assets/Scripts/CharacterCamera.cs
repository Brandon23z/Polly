using UnityEngine;
using System.Collections;

public class CharacterCamera : MonoBehaviour {


		public float speedH = 2.0f;
		public float speedV = 2.0f;

		private float yaw = 0.0f;
		private float pitch = 0.0f;

		//The players ability to look around
		void Update () {
			yaw += speedH * Input.GetAxis("Mouse X");
			pitch -= speedV * Input.GetAxis("Mouse Y");

		if (pitch >= 90)//limit the players look limits
			pitch = 90;	//up
		if (pitch <= -60)
			pitch = -60;	//down
		
			transform.eulerAngles = new Vector3(pitch, yaw, 0.0f); //transform the position

		}

}
