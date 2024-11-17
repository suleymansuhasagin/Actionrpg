using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletController : MonoBehaviour
{
    public float moveSpeed;
    public int damageToPlayer;
    private Vector3 moveDir;
    void Start()
    {
        moveDir = PlayerController.Instance.transform.position - transform.position;
        moveDir.Normalize();
    }

    
    void Update()
    {
        transform.position += moveDir * moveSpeed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.tag == "Player")
        {
            HealthController.Instance.DamagePlayer(damageToPlayer);
        }
        Destroy(gameObject);
    }
    private void OnBecameInvisible() 
    {
        Destroy(gameObject);    
    }
}
