using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    public int healthToRestore;
    public float lifetime;
    public float waitToPickup = .5f;
    void Start()
    {
        if(lifetime > 0)
        {
        Destroy(gameObject, lifetime);
        }
    }

    
    void Update()
    {
        if(waitToPickup > 0)
        {
            waitToPickup -= Time.deltaTime;
        }
    }
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.tag == "Player" && waitToPickup <= 0)
        {
            HealthController.Instance.RestoreHealth(healthToRestore);

            Destroy(gameObject);

            AudioManager.Instance.PlaySFX(6);
        }
    }   
}
