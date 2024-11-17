using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Rigidbody2D enemyRigidBody;
    public BoxCollider2D area;
    public Animator enemyAnim;
    public bool shouldChase;
    private bool isChasing;
    public float chaseSpeed, rangeToChase, waitAfterHitting;
    public float moveSpeed;
    public float waitTime, moveTime;
    public int damageToDeal = 10;
    private float waitCounter, moveCounter;
    private Vector2 moveDir;
    private bool isKnockingBack;
    public float knockBackTime, knockBackForce, waitAfterKnocking;
    private float knockBackCounter, knockWaitCounter;
    private Vector2 knockDir;
    public bool shouldShoot;
    public GameObject bullet;
    public float timeBetweenShots;
    private float shotCounter;
    public Transform shotPoint; 
    void Start()
    {
        waitCounter = Random.Range(waitTime * .75f, waitTime * 1.25f);
        enemyRigidBody = GetComponent<Rigidbody2D>();
        shotCounter = timeBetweenShots;
    }

    
    void Update()
    {
        if(!isKnockingBack)
        {
        if(!isChasing)
        {
        if(waitCounter > 0)
        {
            waitCounter =  waitCounter - Time.deltaTime;  

            enemyRigidBody.velocity = Vector2.zero;

            if(waitCounter <= 0)
            {
                moveCounter = Random.Range(moveTime * .75f, moveTime * 1.25f);

                enemyAnim.SetBool("moving", true);
                moveDir = new Vector2(Random.Range(-1f,1f), Random.Range(-1f,1f));
                moveDir.Normalize();
            }
        }
        else
        {
            moveCounter -= Time.deltaTime;

            enemyRigidBody.velocity = moveDir * moveSpeed;

            if(moveCounter <= 0)
            {
                waitCounter = waitTime;

                enemyAnim.SetBool("moving", false);
            }
            if(shouldChase && PlayerController.Instance.gameObject.activeInHierarchy)
            {
                if(Vector3.Distance(transform.position, PlayerController.Instance.transform.position) < rangeToChase)
                {
                    isChasing = true;
                }
            }
        }
            if(shouldShoot)
            {
                shotCounter -= Time.deltaTime;
                if(shotCounter <= 0)
                {
                    shotCounter = timeBetweenShots;

                    Instantiate(bullet, shotPoint.position, shotPoint.rotation);
                }
            }
        }
        else
        {
            if(waitCounter > 0)
            {
                waitCounter -= Time.deltaTime;

                enemyRigidBody.velocity = Vector2.zero;
                if(waitCounter <= 0)
                {
                    enemyAnim.SetBool("moving", true);
                }
            }
            else
            {
                moveDir = PlayerController.Instance.transform.position - transform.position;
                moveDir.Normalize();
                enemyRigidBody.velocity = moveDir * chaseSpeed;
            }

            if(Vector3.Distance(transform.position, PlayerController.Instance.transform.position) > rangeToChase || !PlayerController.Instance.gameObject.activeInHierarchy)
            {
                isChasing = false;

                waitCounter = waitTime;
                
                enemyAnim.SetBool("moving", false);
            }
        }
        }
        else
        {
            if(knockBackCounter > 0)
            {
                knockBackCounter -= Time.deltaTime;
                enemyRigidBody.velocity = knockDir * knockBackForce;

                if(knockBackCounter <= 0)
                {
                    knockWaitCounter = waitAfterKnocking;
                }
            }
            else
            {
                knockWaitCounter -= Time.deltaTime;
                
                enemyRigidBody.velocity = Vector2.zero;
                if(knockWaitCounter <= 0)
                {
                    isKnockingBack = false;
                }
            }
        }
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, area.bounds.min.x + 1f, area.bounds.max.x - 1f), Mathf.Clamp(transform.position.y, area.bounds.min.y + 1f, area.bounds.max.y - 1f), transform.position.z);

    }
    private void OnCollisionEnter2D(Collision2D other) 
    {
        if(other.gameObject.tag == "Player")
        {
            if(isChasing)
            {
                waitCounter = waitAfterHitting;
                enemyAnim.SetBool("moving", false);
                PlayerController.Instance.KnockBack(transform.position);
                HealthController.Instance.DamagePlayer(damageToDeal);
            }
        }
    }
    public void KnockBack(Vector3 knockerPosition)
    {
        knockBackCounter = knockBackTime;
        isKnockingBack = true;

        knockDir = transform.position - knockerPosition;
        knockDir.Normalize();
    }
}
