using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VictoryScene : MonoBehaviour
{
    public string sceneToLoad;
    // Start is called before the first frame update
    void Start()
    {
        if(GameManager.Instance != null)
        {
            Destroy(GameManager.Instance.gameObject);
            GameManager.Instance = null;
        }

        if(PlayerController.Instance != null)
        {
            Destroy(PlayerController.Instance.gameObject);
            PlayerController.Instance = null;
        }
        SaveManager.instance.activeSave.hasBegun = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene(sceneToLoad);
    }
}
