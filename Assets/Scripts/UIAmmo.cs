using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIAmmo : MonoBehaviour {

	Text ammoCount;
	public GameObject pistol;
	private bulletprojectile bullP;

	// Use this for initialization
	void Start ()
	{
		bullP = pistol.GetComponent<bulletprojectile> (); //gets the bulletprojectile component from the pistol
		ammoCount = this.GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		ammoCount.text = bullP.ammoCount.ToString(); //update the ammo count text
	}
}
