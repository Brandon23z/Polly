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

	private void OnTriggerEnter(Collider other)
	{
		if(other.tag == "Player")
		{
			if (bullP.ammoCount > 5) 
			{
				bullP.ammoCount = bullP.maxAmmo;
			}
			else 
			{
				bullP.ammoCount += ammoVal;

			}

			Destroy (this.gameObject);
		}
	}
}
