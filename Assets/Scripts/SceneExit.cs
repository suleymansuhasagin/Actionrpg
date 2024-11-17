using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneExit : MonoBehaviour
{
    public string sceneToLoad;
    public Vector3 exitLocation;
    
   private void OnTriggerEnter2D(Collider2D other) 
   {
        if(other.tag == "Player")
        {
            PlayerController.Instance.transform.position = exitLocation;

            PlayerController.Instance.theRB.velocity = Vector2.zero;
            PlayerController.Instance.canMove = false;

            UIController.Instance.blackoutScreen.SetActive(true);

            SceneManager.LoadScene(sceneToLoad);
        }
   }
}
