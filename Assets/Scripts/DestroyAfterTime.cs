using UnityEngine;
using System.Collections;

public class DestroyAfterTime : MonoBehaviour {

	public float lifetime = 6.0f; //lifetime of the object
	
	// Use this for initialization
	void Start () {
		Destroy(gameObject, lifetime); //destroy the object in the lifetime
	}
}
