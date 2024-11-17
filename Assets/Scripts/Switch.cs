using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    private bool inRange;
    public GameObject objectToSwitchOff;
    private bool isOn;
    public SpriteRenderer switchSprite;
    public Sprite offSprite, onSprite;
    void Start()
    {
        
    }

    
    void Update()
    {
        if(inRange)
        {
            if(Input.GetMouseButtonDown(0))
            {
                {
                    isOn = !isOn;

                    if(isOn)
                    {
                        switchSprite.sprite = onSprite;
                    }
                    else
                    {
                        switchSprite.sprite = offSprite;
                    }
                    objectToSwitchOff.SetActive(!isOn);
                }
            }
        }
        
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.tag == "Player") 
        {
            inRange = true;
        }   
    }
    private void OnTriggerExit2D(Collider2D other) 
    {
        if(other.tag == "Player") 
        {
            inRange = false;
        }   
    }
}
