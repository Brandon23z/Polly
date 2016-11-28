using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour
{
    public BoxCollider territory;
    GameObject player;
    bool playerInTerritory;

    public GameObject enemy;
    BasicEnemy basicenemy;

    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Character");
        basicenemy = enemy.GetComponent<BasicEnemy>();
        playerInTerritory = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerInTerritory == true)
        {
            basicenemy.MoveToPlayer();
        }

        if (playerInTerritory == false)
        {
            basicenemy.Rest();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            playerInTerritory = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject == player)
        {
            playerInTerritory = false;
        }
    }
}

public class BasicEnemy : MonoBehaviour
{
    public Transform target;
    public float speed = 3f;
    public float attack1Range = 1f;
    public int attack1Damage = 1;
    public float timeBetweenAttacks;


    // Use this for initialization
    void Start()
    {
        Rest();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void MoveToPlayer()
    {
        //rotate to look at player
        transform.LookAt(target.position);
        transform.Rotate(new Vector3(0, -90, 0), Space.Self);

        //move towards player
        if (Vector3.Distance(transform.position, target.position) > attack1Range)
        {
            transform.Translate(new Vector3(speed * Time.deltaTime, 0, 0));
        }
    }

    public void Rest()
    {

    }
}
