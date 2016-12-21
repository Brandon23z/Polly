using UnityEngine;
using System.Collections;

public class AmmoPickup : MonoBehaviour
{
	public GameObject pistol;
	private bulletprojectile bullP;
	public int ammoVal;

	void Start()
	{
		bullP = pistol.GetComponent<bulletprojectile> ();

	}

	//if a ammo pack is picked up
	private void OnTriggerEnter(Collider other)
	{
		if(other.tag == "Player")
		{
			if (bullP.ammoCount > 5) 
			{
				bullP.ammoCount = bullP.maxAmmo; //give the max ammo
			}
			else 
			{
				bullP.ammoCount += ammoVal;  //add the current value of the ammo pack

			}

			Destroy (this.gameObject); //destroy the ammo pack
		}
	}
}
