using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressActivator : MonoBehaviour
{
    public string progressToCheck;
    public bool deactivateIfMarked;
    void Start()
    {  
        bool isMarked = SaveManager.instance.CheckProgress(progressToCheck);


        if(deactivateIfMarked)
        {
            gameObject.SetActive(!isMarked);
        }
        else
        {
            gameObject.SetActive(isMarked);
        }
    }

    
    void Update()
    {
        
    }
}
