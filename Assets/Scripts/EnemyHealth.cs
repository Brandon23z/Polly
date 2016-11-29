using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour
{
    public int startingHealth = 10;      
    public int currentHealth;                 
    public float sinkSpeed = 2.5f;            
    public int scoreValue = 10;          


    Animator anim;                            
    ParticleSystem hitParticles;               
    CapsuleCollider capsuleCollider;            
    bool isDead;                              


    void Awake()
    {
        // Setting up the references.
        anim = GetComponent<Animator>();
        hitParticles = GetComponentInChildren<ParticleSystem>();
        capsuleCollider = GetComponent<CapsuleCollider>();
        
        currentHealth = startingHealth;
    }

    public void TakeDamage(int amount, Vector3 hitPoint)
    {
        if (isDead)
            return;
        
        currentHealth -= amount;
        
        hitParticles.transform.position = hitPoint;
        if (currentHealth <= 0)
        {
            Death();
        }
    }


    void Death()
    {
        isDead = true;
        
        capsuleCollider.isTrigger = true;
        
        anim.SetTrigger("Dead");
    }


    public void StartSinking()
    {
        GetComponent<NavMeshAgent>().enabled = false;
        
        GetComponent<Rigidbody>().isKinematic = true;
        
        Destroy(gameObject, 2f);
    }
}
