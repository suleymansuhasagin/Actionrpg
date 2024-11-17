using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public GameObject continueButton;
    public string startScene;
    
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

        if(SaveManager.instance.activeSave.hasBegun)
        {
            continueButton.SetActive(true);
        }
    }

    
    void Update()
    {
        
    }

    public void StartGame()
    {
        SceneManager.LoadScene(startScene);
        SaveManager.instance.ResetSave();
        SaveManager.instance.activeSave.hasBegun = true;
    }

    public void QuitGame()
    {
        Debug.Log("Quitting Game");

        Application.Quit();
    }
    public void Continue()
    {
        SceneManager.LoadScene(SaveManager.instance.activeSave.currentScene);
    }
}
