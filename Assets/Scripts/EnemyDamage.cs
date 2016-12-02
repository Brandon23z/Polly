using UnityEngine;
using System.Collections;

public class EnemyDamage : MonoBehaviour {

	public float damage = 50;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	private void OnTriggerEnter(Collider other)
	{
		if(other.tag == "Player")
		{
			other.SendMessage("TakeDamage", damage);
		}
	}
}
