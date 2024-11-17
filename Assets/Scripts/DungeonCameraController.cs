using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonCameraController : MonoBehaviour
{
    public static DungeonCameraController instance;
    public Vector3 targetPoint;
    public float moveSpeed;
    public bool inBossRoom;
    private Vector3 limitUpper, limitLower;
    private void Awake() 
    {
        instance = this;    
    }
    void Start()
    {
        targetPoint.z = transform.position.z;
    }

    
    void Update()
    {
        if(inBossRoom)
        {
            targetPoint.y = Mathf.Clamp(PlayerController.Instance.transform.position.y, limitLower.y, limitUpper.y);
        }

        transform.position = Vector3.MoveTowards(transform.position, targetPoint, moveSpeed * Time.deltaTime);
    }
    public void ActivateBossRoom(Vector3 upper, Vector3 lower)
    {
        inBossRoom = true;
        limitUpper = upper;
        limitLower = lower;
    }
}
