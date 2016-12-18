using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EnemyDamage : MonoBehaviour {

	public float damage = 50;
	public float currentHealth = 100;
	//private float maxHealth = 100;
	public float currWidth = 300;
	public float maxWidth = 300;
	public float currHeight;
	
	// Use this for initialization
	void Start () 
	{
		currHeight = 25;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	private void OnCollisionEnter(Collision other)
	{
		if(other.gameObject.tag == "Player")
		{
			Image temp = GameObject.FindGameObjectWithTag ("CurrentHealth").GetComponent<Image>();
			temp.rectTransform.sizeDelta = new Vector2((currWidth - (maxWidth/10)) ,currHeight);
		}
	}
}
