using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HealthBar : MonoBehaviour {

	RectTransform healthbar;
	public Canvas Health;
	public float hitValue = .2f;
	public float defaultHeight = .25f;
	public float defaultWidth = 2f;
	public float currHealth;
	// Use this for initialization
	void Start ()
	{
		healthbar = Health.GetComponentInChildren<RectTransform> ();

		currHealth = 2f;
	}



	void OnColliderEnter (Collider other) 
	{
		if (other.gameObject.tag == "Enemy")
		{
			healthbar.sizeDelta = new Vector2 ((currHealth-hitValue), defaultHeight);
			currHealth = currHealth - hitValue;
		}
	}


}
