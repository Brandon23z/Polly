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
	private bool canFire;	//can the player fire the gun

	//On Start run these.
	void Start()
	{
		canFire = true;	//The player can fire.
		ammoCount = 15;	//beginning ammo count
	}

	void Update ()
	{
		//if the game is paused and the player presses enter
		if (PauseCanvas.GetComponent<Canvas> ().enabled == true && Input.GetKeyDown (KeyCode.Return)) 
		{
			Application.Quit (); //Quit the Game
		}

		//if the player presses TAB
		if (Input.GetButtonDown("Scoreboard")) 
		{
			//Display the Scoreboard
			ScoreCanvas.GetComponent<Canvas>().enabled = !ScoreCanvas.GetComponent<Canvas>().enabled;
		}
		//If the player presses escape
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			//Pause the Game
			PauseGame ();

		}
		//Change the rate of fire
		if (Input.GetKeyDown(KeyCode.C))
		{
			setRoF ();
		}

		//Prevents the player to get more ammo than what the max is
		if (Input.GetKeyDown (KeyCode.R) && ammoCount < 15) 
		{
			ammoCount = maxAmmo;
		}

		//is the rate of fire set to automatic
		if(isFullyAutomatic)
		{
			//shooting with fully automatic
			if(Input.GetButton ("Fire1") && ammoCount != 0 && canFire == true)
			{
				ammoCount--; //take a bullet out of ammo
				AudioSource.PlayClipAtPoint (gunShot, Spawnpoint.transform.position);//gunshot
				Flash (); //muzzle flash
				Rigidbody clone;	//creates a clone for the bullet
				clone = (Rigidbody)Instantiate(projectile, Spawnpoint.position, projectile.rotation);
				clone.gameObject.AddComponent (typeof(BulletHit)); //adds the bullet hit component
				clone.velocity = Spawnpoint.TransformDirection (Vector3.forward*bulletSpeed);


				canFire = false;	//cannot fire while firing until after delay
				Invoke ("Fire", bulletDelay/2);	//

			}
		}
		//not fully automatic
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

	//muzzle flash 
	void Flash()
	{
		GameObject muzzleClone;
		muzzleClone = (GameObject)Instantiate (muzzleFlash, muzzleSpawn.position, muzzleSpawn.rotation);
		Destroy (muzzleClone, .025f); //destroy the flash
	}

	void setRoF()
	{
		isFullyAutomatic = !isFullyAutomatic;
	}

	void Fire ()
	{
		canFire = true;
	}

	//pause the game
	public void PauseGame()
	{
		//bring up the appropriate canvas
		GameCanvas.GetComponent<Canvas> ().enabled = !GameCanvas.GetComponent<Canvas> ().enabled;
		PauseCanvas.GetComponent<Canvas> ().enabled = !PauseCanvas.GetComponent<Canvas> ().enabled;
		//set the cursor to be visible
		Cursor.visible = !Cursor.visible;
		//pause/unpause the time
		Time.timeScale = 1f - Time.timeScale;

	

	}



}
