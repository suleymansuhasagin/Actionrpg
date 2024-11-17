using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    public static UIController Instance;
    public Slider healthSlider, staminaSlider;
    public TMP_Text healthText;
    public TMP_Text staminaText;
    public TMP_Text coinsText;
    public string mainMenuScene;
    public GameObject pauseScreen;
    public GameObject blackoutScreen;
    public Slider bossHealthSlider;
    public TMP_Text bossHealthText;
    public GameObject deathScreen;
    
    private void Awake() 
    {
        if(Instance == null)
        {
            Instance = this;
        }    
    }
    void Start()
    {
        UpdateHealth();
        UpdateStamina();
        UpdateCoins();
    }

    
    void Update()
    {
        
    }

    public void UpdateHealth()
    {
        healthSlider.maxValue = HealthController.Instance.maxHealth;
        healthSlider.value = HealthController.Instance.currentHealth;
        healthText.text = "HEALTH: " + HealthController.Instance.currentHealth + "/" + HealthController.Instance.maxHealth;
    }

    public void UpdateStamina()
    {
        staminaSlider.maxValue = PlayerController.Instance.totalStamina;
        staminaSlider.value = PlayerController.Instance.currentStamina;
        staminaText.text = "STAMINA: " + Mathf.RoundToInt(PlayerController.Instance.currentStamina) + "/" +  PlayerController.Instance.totalStamina;
    }
    public void UpdateCoins()
    {
        coinsText.text = "Coins: " + GameManager.Instance.currentCoins;
    }

    

    public void Resume()
    {
        GameManager.Instance.PauseUnpause();
    }

    public void GotoMainMenu()
    {
        SceneManager.LoadScene(mainMenuScene);

        Time.timeScale = 1f;
    }
    public void QuitGame()
    {
        Debug.Log("Quitting Game");

        Application.Quit();
    }
}
