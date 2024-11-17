using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    public string charName;
    public int playerLevel = 1;
    public int currentXP;
    public int[] expToNextLevel;
    public int maxLevel = 100; 
    public int baseEXP = 1000;

    public int currentHP;
    public int maxHP = 100;
    public int currentMP;
    public int maxMP = 30;
    public int[] mpLvlBonus;
    public int strength;
    public int defence;
    public int weaponPower;
    public int armorPower;
    public string equippedWeapon;
    public string equippedArmor;
    public Sprite charImage;
    void Start()
    {
        expToNextLevel = new int[maxLevel];
        expToNextLevel[1] = baseEXP;

        for(int i = 2; i < expToNextLevel.Length; i++)
        {
            expToNextLevel[i] = Mathf.FloorToInt(expToNextLevel[i - 1] * 1.05f);
        }
    }

    
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.K))
        {
            AddEXP(500);
        }
    }

    public void AddEXP(int expToAdd)
    {
        currentXP += expToAdd;
        if(playerLevel < maxLevel)
        {
        if(currentXP > expToNextLevel[playerLevel])
        {
            currentXP -= expToNextLevel[playerLevel];

            playerLevel++;

            if(playerLevel % 2 == 0)
            {
                strength++;
            }
            else
            {
                defence++;
            }

            maxHP = Mathf.FloorToInt(maxHP * 1.05f);
            currentHP = maxHP;
            maxMP = maxMP + mpLvlBonus[playerLevel];
            currentMP = maxMP;
        }
        }
        if(playerLevel >= maxLevel)
        {
            currentXP = 0;
        }
    }
}
