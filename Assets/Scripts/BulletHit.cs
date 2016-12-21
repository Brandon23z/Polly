using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BulletHit : MonoBehaviour
{
	public Transform bloodParticle;
	public GameObject KillSTextObject;
	public GameObject ammoModel;
	public GameObject healthModel;
	public float randomVal;
	public WaveSpawn WaveSpawner;
	private Text KillsText;
	//private Text accuracyText;
	private Text ScoreText;


	void Start()
	{
		ammoModel = GameObject.FindGameObjectWithTag ("Ammo");
		healthModel = GameObject.FindGameObjectWithTag ("HealthPack");
		WaveSpawner = GameObject.FindGameObjectWithTag ("WaveSpawnerScript").GetComponent<WaveSpawn>();
		KillsText = GameObject.FindGameObjectWithTag("KillText").GetComponent<Text> ();
		//accuracyText = GameObject.FindGameObjectWithTag ("AccuracyText").GetComponent<Text> ();
		ScoreText  = GameObject.FindGameObjectWithTag ("ScoreText").GetComponent<Text> ();
	}

	//on collision with the bullet
    void OnCollisionEnter(Collision other)
    {
		//if the bullet collides with enemy
		if (other.gameObject.tag == "Enemy")
		{
			ContactPoint contact = other.contacts[0];
			Vector3 pos = contact.point;

			//create the blood effect
			for(int i=0; i<20; i++)
			{
				//random rotation for the blood to make it spread out
				Quaternion rot = Random.rotation;
				Instantiate(bloodParticle, pos, rot);
			}

			//random val 0.0 to 1.0
			randomVal = Random.value;

			if (randomVal <= .1f) //Drop Health or Ammo
			{
				int temp = Random.Range (1, 11);

				if (temp <=6)//if the random number is 7 or less 
				{
					Instantiate (ammoModel, pos, ammoModel.transform.rotation); //ammo drop
				} 
				else 
				{ 
					Instantiate (healthModel, pos, healthModel.transform.rotation); //drop health
				}
			}

			WaveSpawner.enemyCount--; //delete an enemy from the count
			WaveSpawner.kills++;	  //add a kill to the kill counter
			KillsText.text = "Kills: " + WaveSpawner.kills; //update the scoreboard text

			//if the enemies name starts with a B
			if (other.gameObject.name.StartsWith ("B"))//B for Block Horror
			{
				WaveSpawner.Score += WaveSpawner.BlockVal * WaveSpawner.waveNumb; //Add their score value to the score

			} 
			else
			{
				WaveSpawner.Score += WaveSpawner.TrapVal * WaveSpawner.waveNumb; //Add their score value to the score
			}
			ScoreText.text = "Score: " + WaveSpawner.Score; //update score
			DestroyObject (other.gameObject);	//destroy the enemies gameobject
		}
			
		Destroy (gameObject); //destroy the bullet
		
    }
}
