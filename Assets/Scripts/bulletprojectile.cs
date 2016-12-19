using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class bulletprojectile : MonoBehaviour
{
	
	public Canvas GameCanvas;
	public Canvas PauseCanvas;
	public Canvas ScoreCanvas;
	public Rigidbody projectile;
	public GameObject muzzleFlash;
	public Transform muzzleSpawn;
	public Transform Spawnpoint;
	public AudioClip gunShot;
	public float bulletSpeed = 70;
	public int ammoCount;

	public int maxAmmo = 15;
	public float bulletDelay = 0.650F;
	public bool isFullyAutomatic = false;
	private bool canFire;

	void Start()
	{
		canFire = true;
		ammoCount = 15;
	}

	void Update ()
	{
		if (Input.GetButtonDown("Scoreboard")) 
		{
			ScoreCanvas.GetComponent<Canvas>().enabled = !ScoreCanvas.GetComponent<Canvas>().enabled;
		}
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			PauseGame ();

		}
		if (Input.GetKeyDown(KeyCode.C))
		{
			setRoF ();
		}

		if (Input.GetKeyDown (KeyCode.R) && ammoCount < 15) 
		{
			ammoCount = maxAmmo;
		}

		if(isFullyAutomatic)
		{
			if(Input.GetButton ("Fire1") && ammoCount != 0 && canFire == true)
			{
				ammoCount--;
				AudioSource.PlayClipAtPoint (gunShot, Spawnpoint.transform.position);
				Flash ();
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
			Flash ();
			Rigidbody clone;
			clone = (Rigidbody)Instantiate(projectile, Spawnpoint.position, projectile.rotation);
			clone.gameObject.AddComponent (typeof(BulletHit));
			clone.velocity = Spawnpoint.TransformDirection (Vector3.forward*bulletSpeed);
			canFire = false;
			Invoke ("Fire", bulletDelay);
		}

	}

	void Flash()
	{
		GameObject muzzleClone;
		muzzleClone = (GameObject)Instantiate (muzzleFlash, muzzleSpawn.position, muzzleSpawn.rotation);
		Destroy (muzzleClone, .05f);
	}

	void setRoF()
	{
		isFullyAutomatic = !isFullyAutomatic;
	}

	void Fire ()
	{
		canFire = true;
	}

	public void PauseGame()
	{
		GameCanvas.GetComponent<Canvas> ().enabled = !GameCanvas.GetComponent<Canvas> ().enabled;
		PauseCanvas.GetComponent<Canvas> ().enabled = !PauseCanvas.GetComponent<Canvas> ().enabled;
		Cursor.visible = !Cursor.visible;
		Time.timeScale = 1f - Time.timeScale;

	}



}
