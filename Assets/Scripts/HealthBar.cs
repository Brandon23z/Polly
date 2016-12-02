using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HealthBar : MonoBehaviour {

	/*RectTransform healthbar;
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



	void OnTriggerEnter (Collider other) 
	{
		if (other.gameObject.tag == "Enemy")
		{
			healthbar.sizeDelta = new Vector2 ((currHealth-hitValue), defaultHeight);
			currHealth = currHealth - hitValue;
		}
	}*/
	
	public Image CurrentHealthBar;
	
	public float currentHealth = 100;
	private float maxHealth = 100;
	
	private void Start()
	{
		UpdateHealthBar();
	}
	
	private void UpdateHealthBar()
	{
		float ratio = currentHealth/maxHealth;
		CurrentHealthBar.rectTransform.localScale = new Vector3(ratio,1,1);
	}
	
	private void TakeDamage(float damage)
	{
		currentHealth -= damage;
		if(currentHealth < 0)
		{
			currentHealth = 0;
		}
		if(currentHealth > maxHealth)
		{
			currentHealth = maxHealth;
		}
		UpdateHealthBar();
	}
}
