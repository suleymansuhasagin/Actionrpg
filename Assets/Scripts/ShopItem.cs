using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopItem : MonoBehaviour
{
    [TextArea]
    public string description;
    public int itemCost;
    public bool itemActive;
    public bool isHealthUpgrade, isStaminaUpgrade;
    public int amountToAdd;

    public bool removeAfterPurchase;
    void Start()
    {
        
    }

    
    void Update()
    {
        if(itemActive)
        {
            if(Input.GetMouseButtonDown(0))
            {
                if(GameManager.Instance.currentCoins >= itemCost)
                {
                    GameManager.Instance.currentCoins -= itemCost;
                    UIController.Instance.UpdateCoins();

                    if(isHealthUpgrade)
                    {

                        HealthController.Instance.maxHealth += amountToAdd;
                        HealthController.Instance.currentHealth += amountToAdd;
                        SaveManager.instance.activeSave.maxHealth = HealthController.Instance.maxHealth;
                        UIController.Instance.UpdateHealth();
                    }

                    if(isStaminaUpgrade)
                    {
                        PlayerController.Instance.totalStamina += amountToAdd;
                        PlayerController.Instance.currentStamina += amountToAdd;
                        SaveManager.instance.activeSave.maxStamina =PlayerController.Instance.totalStamina;
                        UIController.Instance.UpdateStamina();
                    }
                    SaveManager.instance.activeSave.currentCoins = GameManager.Instance.currentCoins;
                    if(removeAfterPurchase)
                    {
                        gameObject.SetActive(false);
                    }
                    DialogScript.Instance.dialogBox.SetActive(false);
                    itemActive = false;
                }
                else
                {
                    DialogScript.Instance.dialogText.text = "You don't have enough Gold!";
                }
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.tag == "Player")
        {
            itemActive = true;

            DialogScript.Instance.dialogBox.SetActive(true);
            DialogScript.Instance.dialogText.text = description;
        }    
    }
    private void OnTriggerExit2D(Collider2D other) 
    {
        if(other.tag == "Player")
        {
            itemActive = false;

            DialogScript.Instance.dialogBox.SetActive(false);
        }    
    }
}
