using UnityEngine;
using System.Collections;

public class DestroyOnTerrainCollision : MonoBehaviour {
	public float lifetime = 2.0f;
	void OnCollisionEnter(Collision other)
    {
		if(other.gameObject.tag == "Terrain")
		{
			Destroy(gameObject, lifetime);
		}
	}
}
