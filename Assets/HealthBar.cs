using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HealthBar : MonoBehaviour {

	private Image ima;
	public Sprite someOtherSprite;
	public int health;
	public int maxHealth;

	// Use this for initialization
	void Start ()
	{
		health = 10;
		maxHealth = 10;
		ima = this.GetComponent<Image> ();
	}


	// Update is called once per frame
	void Update () 
	{
		if (Input.GetKeyDown (KeyCode.H))
		{
			health--;
			LoadSprite ();
		}
		if (Input.GetKeyDown (KeyCode.J))
		{
			health = maxHealth;
			LoadSprite ();
		}

	}

	public void LoadSprite ()
	{
		if (health == 9) 
		{
			someOtherSprite = Resources.Load<Sprite> ("9Health");

			ima.sprite = someOtherSprite;
		}
	}
}
