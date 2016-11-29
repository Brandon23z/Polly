using UnityEngine;
using System.Collections;

public class bulletprojectile : MonoBehaviour
{

	public Rigidbody projectile;
	public Transform Spawnpoint;
	public AudioClip gunShot;
	public float bulletSpeed = 70;
	public int ammoCount = 15;
	public float bulletDelay = 0.650F;
	public bool isFullyAutomatic = false;
	private bool canFire;

	void Start()
	{
		canFire = true;
	}

	void Update ()
	{
		if (Input.GetKeyDown(KeyCode.C))
		{
			setRoF ();
		}
		
		if(isFullyAutomatic)
		{
			if(Input.GetButton ("Fire1") && ammoCount != 0 && canFire == true)
			{
				ammoCount--;
				AudioSource.PlayClipAtPoint (gunShot, Spawnpoint.transform.position);
				Rigidbody clone;
				clone = (Rigidbody)Instantiate(projectile, Spawnpoint.position, projectile.rotation);
				clone.gameObject.AddComponent (typeof(BulletHit));
				clone.velocity = Spawnpoint.TransformDirection (Vector3.forward*bulletSpeed);

				canFire = false;
				Invoke ("Fire", bulletDelay/2);

			}
		}
		else if (Input.GetButtonDown ("Fire1") && ammoCount != 0 && canFire == true)
		{
			ammoCount--;
			AudioSource.PlayClipAtPoint (gunShot, Spawnpoint.transform.position);
			Rigidbody clone;
			clone = (Rigidbody)Instantiate(projectile, Spawnpoint.position, projectile.rotation);
			clone.gameObject.AddComponent (typeof(BulletHit));
			clone.velocity = Spawnpoint.TransformDirection (Vector3.forward*bulletSpeed);
			canFire = false;
			Invoke ("Fire", bulletDelay);
		}

	}

	void setRoF()
	{
		isFullyAutomatic = !isFullyAutomatic;
	}

	void Fire ()
	{
		canFire = true;
	}

}
