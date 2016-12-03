using UnityEngine;
using System.Collections;

public class BulletHit : MonoBehaviour
{
	public Transform bloodParticle;

    void OnCollisionEnter(Collision other)
    {
		if (other.gameObject.tag == "Enemy")
		{
			ContactPoint contact = other.contacts[0];
			Quaternion rot = Quaternion.FromToRotation(Vector3.up, contact.normal);
			Vector3 pos = contact.point;
			for(int i=0; i<20; i++)
			{
				Instantiate(bloodParticle, pos, rot);
			}
			DestroyObject (other.gameObject);
		}
			Destroy (gameObject);
		
    }
}
