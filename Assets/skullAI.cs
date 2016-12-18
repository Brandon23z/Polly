using UnityEngine;
using System.Collections;

public class skullAI : MonoBehaviour {

	public Transform target;
	public int moveSpeed = 3;
	public int rotationSpeed = 3;

	public Transform myTransform;


	public void Awake()
	{
		myTransform = transform;
	}


	void Start()
	{
		target = GameObject.FindWithTag("Weapon").transform;
	}


	void Update()
	{
		//rotate to look at the player
		myTransform.rotation = Quaternion.Slerp(myTransform.rotation,
			Quaternion.LookRotation(target.position - myTransform.position), rotationSpeed * Time.deltaTime);

	}
}
