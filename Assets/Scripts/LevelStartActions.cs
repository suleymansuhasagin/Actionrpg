using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelStartActions : MonoBehaviour
{
    
    void Start()
    {
        PlayerController.Instance.DoAtLevelStart();
        SaveManager.instance.activeSave.currentScene = SceneManager.GetActiveScene().name;
        SaveManager.instance.activeSave.sceneStartPosition = PlayerController.Instance.transform.position;

        SaveManager.instance.SaveInfo();
    }

    
}
