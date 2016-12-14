using UnityEngine;
using System.Collections;

public class BulletHit : MonoBehaviour
{
	public Transform bloodParticle;
	public GameObject ammoModel;
	public float randomVal;
	public WaveSpawn WaveSpawner;


	void Start()
	{
		ammoModel = GameObject.FindGameObjectWithTag ("Ammo");
		WaveSpawner = GameObject.FindGameObjectWithTag ("WaveSpawnerScript").GetComponent<WaveSpawn>();
	}

    void OnCollisionEnter(Collision other)
    {
		if (other.gameObject.tag == "Enemy")
		{
			ContactPoint contact = other.contacts[0];
			Quaternion rot = Quaternion.FromToRotation(Vector3.up, contact.normal);
			Vector3 pos = contact.point;

			for(int i=0; i<20; i++)
			{
				Instantiate(bloodParticle, pos, rot);
			}


			randomVal = Random.value;

			if (randomVal <= .05f) 
			{
				Instantiate(ammoModel, pos, ammoModel.transform.rotation);
			}
			WaveSpawner.enemyCount--;
			DestroyObject (other.gameObject);
		}

			Destroy (gameObject);
		
    }
}
