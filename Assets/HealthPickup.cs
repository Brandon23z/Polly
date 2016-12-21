using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HealthPickup : MonoBehaviour {

	public GameObject player;
	private HealthBar currHealth;

	void Start()
	{
		currHealth = player.GetComponent<HealthBar> (); //players healthbar components
	}

	//collision with the healthpack
	private void OnTriggerEnter(Collider other)
	{
		//make sure the collision is with the player
		if(other.tag == "Player")
		{
			 
			currHealth.AddHealth ();//go to the add health function in HealthBar

			Destroy (this.gameObject); //destroy the healthpack
		}
	}
}
