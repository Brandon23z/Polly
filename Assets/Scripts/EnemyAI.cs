using UnityEngine;
using System.Collections;

public class EnemyAI : MonoBehaviour
{
    public Transform target;
    public int moveSpeed = 3;
    public int rotationSpeed = 3;

    public Transform myTransform;


    public void Awake()
    {
        myTransform = transform;
    }


    void Start()
    {
        target = GameObject.FindWithTag("Weapon").transform; //find the players gameobject
    }


    void Update()
    {
        //rotate to look at the player
        myTransform.rotation = Quaternion.Slerp(myTransform.rotation,
        	Quaternion.LookRotation(target.position - myTransform.position), 
			rotationSpeed * Time.deltaTime);


        //move towards the player
        myTransform.position += myTransform.forward * moveSpeed * Time.deltaTime;

    }
}

