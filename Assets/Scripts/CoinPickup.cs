using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPickup : MonoBehaviour
{
    public static CoinPickup Instance;
    public int coinValue;
    public float waitToPickup = .5f;
    private void Awake() 
    {
        if(Instance == null)
        {
            Instance = this; 
        }   
    }
    void Start()
    {
        
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
            GameManager.Instance.GetCoins(coinValue);

            Destroy(gameObject);

            AudioManager.Instance.PlaySFX(3);
        }    
    }
}
