using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthController : MonoBehaviour
{
    public static HealthController Instance;
    public int currentHealth;
    public int maxHealth;
    public float invincibilityLenght = 1f;
    private float invCounter;
    public GameObject deathEffect;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this; 
        }   
    }   
    void Start()
    {
        maxHealth = SaveManager.instance.activeSave.maxHealth;
        currentHealth = maxHealth;

        UIController.Instance.UpdateHealth();
    }

    
    void Update()
    {
        if(invCounter > 0)
        {
            invCounter -= Time.deltaTime;
        }
    }
    public void DamagePlayer(int damageAmount)
    {
        if(invCounter <= 0)
        {
        currentHealth -= damageAmount;

        invCounter = invincibilityLenght;

        if(currentHealth <= 0)
        {
            currentHealth = 0;

            gameObject.SetActive(false);
            Instantiate(deathEffect, transform.position, transform.rotation);

            AudioManager.Instance.PlaySFX(4);
            GameManager.Instance.Respawn();
        }
        UIController.Instance.UpdateHealth();
        AudioManager.Instance.PlaySFX(7);
        }   
    }
    public void RestoreHealth(int healthToRestore)
    {
        currentHealth += healthToRestore;

        if(currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
        UIController.Instance.UpdateHealth();
    }
}
