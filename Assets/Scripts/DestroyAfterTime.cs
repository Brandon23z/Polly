using UnityEngine;
using System.Collections;

public class DestroyAfterTime : MonoBehaviour {

	public float lifetime = 6.0f;
	
	// Use this for initialization
	void Start () {
		Destroy(gameObject, lifetime);
	}
}
