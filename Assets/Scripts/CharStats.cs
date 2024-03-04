using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharStats : MonoBehaviour
{
    public string charName;
    public int playerLevel = 1;
    public int currentEXP;
    public int[] expToNextLevel;
    public int maxLevel = 100;
    public int baseEXP = 1000;

    public int currentHP;
    public int maxHP = 100;
    public int currentMP;
    public int baseMP = 30;
    public int maxMP;
    public int[] mpLevelBonus;
    public int strength;
    public int defence;
    public int weaponPower;
    public int armorPower;
    public string equippedWeapon;
    public string equippedArmor;
    public Sprite charImage;

    

    // Start is called before the first frame update
    void Start()
    {
        expToNextLevel = new int[maxLevel];
        expToNextLevel[1] = baseEXP;
        for(int i=2; i < expToNextLevel.Length; i++)
        {
            expToNextLevel[i] = (int)(expToNextLevel[i - 1] * 1.05f);
            //expToNextLevel[i] = Mathf.FloorToInt(expToNextLevel[i - 1] * 1.05f);
        }

        mpLevelBonus = new int[maxLevel];
        maxMP = baseMP;
        mpLevelBonus[1] = 12;
        for(int i = 2; i < mpLevelBonus.Length; i++)
        {
            if(i % 3 == 1)
            {
                mpLevelBonus[i] = mpLevelBonus[i - 3] + (int)(2 * 1.15f);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {   
        /*
        if(Input.GetKey(KeyCode.K))
        {
            AddEXP(1000);
        }*/
    }

    public void AddEXP(int expToAdd)
    {
        // theEXP is in case there is large amount of exp earned that would give maybe 2+ levels
        int theExp = expToAdd;
        int theExpVar = 0;
        while (theExp > 0)
        {
            
            if (theExp > expToNextLevel[playerLevel])
            {
                theExpVar = expToNextLevel[playerLevel] - 1;
                
            }
            else
            {
                theExpVar = theExp;
            }
            currentEXP += theExpVar;
            if (playerLevel < maxLevel)
            {
                if (currentEXP > expToNextLevel[playerLevel])
                {
                    currentEXP -= expToNextLevel[playerLevel];
                    playerLevel++;

                    //determine whether to add str of def based on odd or even
                    if (playerLevel % 2 == 0)
                    {
                        strength++;
                    }
                    else
                    {
                        defence++;
                    }

                    maxHP = (int)(maxHP * 1.05f);
                    currentHP = maxHP;

                    maxMP += mpLevelBonus[playerLevel];
                    currentMP = maxMP;
                }
            }

            theExp -= theExpVar;
        }


        /*
        currentEXP += expToAdd;
        if (playerLevel < maxLevel)
        {
            if (currentEXP > expToNextLevel[playerLevel])
            {
                currentEXP -= expToNextLevel[playerLevel];
                playerLevel++;

                //determine whether to add str of def based on odd or even
                if (playerLevel % 2 == 0)
                {
                    strength++;
                }
                else
                {
                    defence++;
                }

                maxHP = (int)(maxHP * 1.05f);
                currentHP = maxHP;

                maxMP += mpLevelBonus[playerLevel];
                currentMP = maxMP;
            }
        }*/

        if(playerLevel >= maxLevel)
        {
            currentEXP = 0;
        }
    }
}
