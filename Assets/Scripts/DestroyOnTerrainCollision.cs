using UnityEngine;
using System.Collections;

public class DestroyOnTerrainCollision : MonoBehaviour {
	
	public float lifetime = 2.0f; //2 second lifetime

	void OnCollisionEnter(Collision other)
    {
		if(other.gameObject.tag == "Terrain") //if it falls on the terrain
		{
			Destroy(gameObject, lifetime);	//destroy it after its lifetime
		}
	}
}
