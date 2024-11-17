using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int currentHealth;

    public GameObject deathEffect;
    private EnemyController theEC;
    public GameObject healthToDrop, coinToDrop;
    public float healthToDropChance, coinDropChance;
    void Start()
    {
        theEC = GetComponent<EnemyController>();
    }

    
    void Update()
    {
        
    }

    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;
        if(currentHealth <= 0)
        {
            if(deathEffect != null)
            {
                Instantiate(deathEffect, transform.position, transform.rotation);
            }

            Destroy(gameObject);

            if(Random.Range(0, 100f) < healthToDropChance && healthToDrop != null)
            {
                Instantiate(healthToDrop, transform.position, transform.rotation);
            }
            if(Random.Range(0, 100f) < coinDropChance && coinToDrop != null)
            {
                Instantiate(coinToDrop, transform.position, transform.rotation);
            }
            AudioManager.Instance.PlaySFX(4);
        }
        theEC.KnockBack(PlayerController.Instance.transform.position);
    }
}
