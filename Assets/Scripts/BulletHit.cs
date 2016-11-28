using UnityEngine;
using System.Collections;

public class BulletHit : MonoBehaviour {


	void OnCollisionEnter(Collision collision)
	{
		Destroy (this.gameObject);
	}
}
