using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HealthPickup : MonoBehaviour {

	public GameObject player;
	private HealthBar currHealth;
	void Start()
	{
		currHealth = player.GetComponent<HealthBar> ();
	}

	private void OnTriggerEnter(Collider other)
	{
		if(other.tag == "Player")
		{
			 
			currHealth.AddHealth ();

			Destroy (this.gameObject);
		}
	}
}
