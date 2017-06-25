using UnityEngine;
using System.Collections;

public class Gun : MonoBehaviour {

	public float damage = 10f;
	public float range = 150f;
	
	public Camera fpsCam;
	// Update is called once per frame
	void Update () {
		if(Input.GetButtonDown("Fire1"))
		{
			shoot();
		}
	}
	
	void shoot()
	{
		RaycastHit hit;
		if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
		{
			Debug.Log(hit.transform.name);
		}
	}
}
