using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordUnlock : MonoBehaviour
{
    public GameObject door;
    public int newSwordDamage, swordSpriteRef;
    public string[] pickupDialog;
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.tag == "Player")
        {
            gameObject.SetActive(false);

            if(door != null)
            {
                door.SetActive(false);
            }

            PlayerController.Instance.UpgradeSword(newSwordDamage, swordSpriteRef);
            if(pickupDialog.Length > 0)
            {
                DialogScript.Instance.ShowDialog(pickupDialog, false); 
            }
        }
    }
}
