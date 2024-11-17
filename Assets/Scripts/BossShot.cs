using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossShot : MonoBehaviour
{
    public float moveSpeed, rotateSpeed;
    public int damageToPlayer;
    private Vector3 moveDir;
    void Start()
    {
        
    }

    
    void Update()
    {
        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z + (rotateSpeed) * Time.deltaTime);
        transform.position += moveDir * moveSpeed * Time.deltaTime;
    }

    public void SetDirection(Vector3 spawnerPosition)
    {
        moveDir = transform.position - spawnerPosition;
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

