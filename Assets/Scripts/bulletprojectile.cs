using UnityEngine;
using System.Collections;

public class bulletprojectile : MonoBehaviour
{

	public Rigidbody projectile;
	public Transform Spawnpoint;
	public float bulletSpeed = 70;
	public int ammoCount = 15;
	private bool canFire;

	void Start()
	{
		canFire = true;
	}

	void Update ()
	{
		if (Input.GetButtonDown ("Fire1") && ammoCount != 0 && canFire == true)
		{
			ammoCount--;
			Rigidbody clone;
			clone = (Rigidbody)Instantiate(projectile, Spawnpoint.position, projectile.rotation);
			clone.gameObject.AddComponent (typeof(BulletHit));
			clone.velocity = Spawnpoint.TransformDirection (Vector3.forward*bulletSpeed);
			canFire = false;
			Invoke ("Fire", 0.650F);
		}

	}

	void Fire ()
	{
		canFire = true;
	}

}
