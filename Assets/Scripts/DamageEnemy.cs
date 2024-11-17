using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageEnemy : MonoBehaviour
{
    public int damageToDeal;
    public GameObject hitEffect;
    
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }
    
    void SpawnHitEffect()
    {
        Instantiate(hitEffect, transform.position, transform.rotation);
    }
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.tag == "Enemy")
        {
            other.GetComponent<EnemyHealth>().TakeDamage(damageToDeal);

            SpawnHitEffect();
        }

        if(other.tag == "Breakable")
        {
            other.GetComponent<BreakableObject>().Break();
            SpawnHitEffect();

        }
        if(other.tag == "Boss")
        {
            other.GetComponent<BossWeakPoint>().DamageBoss(damageToDeal);
            SpawnHitEffect(); 
        }
    }
}
