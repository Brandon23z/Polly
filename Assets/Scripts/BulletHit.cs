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
	void Update()
	{


	}
    void OnCollisionEnter(Collision other)
    {
		
		if (other.gameObject.tag == "Enemy")
		{
			ContactPoint contact = other.contacts[0];
			Vector3 pos = contact.point;

			for(int i=0; i<20; i++)
			{
				Quaternion rot = Random.rotation;
				Instantiate(bloodParticle, pos, rot);
			}


			randomVal = Random.value;

			if (randomVal <= .05f) //Drop Health or Ammo
			{
				int temp = Random.Range (1, 10);

				if (temp % 2 == 0) 
				{
					Instantiate (ammoModel, pos, ammoModel.transform.rotation);
				} 
				else 
				{ 
					Instantiate (healthModel, pos, healthModel.transform.rotation);
				}
			}
			WaveSpawner.enemyCount--;
			WaveSpawner.kills++;
			KillsText.text = "Kills: " + WaveSpawner.kills;
			if (other.gameObject.name.StartsWith ("B"))
			{
				WaveSpawner.Score += WaveSpawner.BlockVal * WaveSpawner.waveNumb;

			} 
			else
			{
				WaveSpawner.Score += WaveSpawner.TrapVal * WaveSpawner.waveNumb;
			}
			ScoreText.text = "Score: " + WaveSpawner.Score;
			DestroyObject (other.gameObject);
		}
			
		Destroy (gameObject);
		
    }
}
