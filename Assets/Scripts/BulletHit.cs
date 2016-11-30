using UnityEngine;
using System.Collections;

public class BulletHit : MonoBehaviour
{
    public float lifetime = 1.0f;

    void Start()
    {
		
    }

    void Update()
    {
		
    }

    void Awake()
    {
      //  Destroy(gameObject, lifetime);
    }

    void OnCollisionEnter(Collision other)
    {
		if (other.gameObject.tag == "Enemy")
		{
			DestroyObject (other.gameObject);
		
		}
	
			Destroy (gameObject);
		
    }
}
