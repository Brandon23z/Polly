using UnityEngine;
using System.Collections;

public class bulletprojectile : MonoBehaviour
{

	public Rigidbody projectile;
	public Transform Spawnpoint;
	public float bulletSpeed = 70;

	void Update ()
	{
		if(Input.GetButtonDown("Fire1"))
		{
			Rigidbody clone;
			clone = (Rigidbody)Instantiate(projectile, Spawnpoint.position, projectile.rotation);
			clone.gameObject.AddComponent (typeof(BulletHit));
			clone.velocity = Spawnpoint.TransformDirection (Vector3.forward*bulletSpeed);
		}

	}

}
