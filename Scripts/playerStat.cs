using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class playerStat : MonoBehaviour
{
    public Object unityChan;
    public static int attack = 20;

    public static float agility = 2.5f;

    public static int strength = 1000;
    public static int currMaxHP = 1000;

    public static int level = 1;

    public static int currExp = 0;
    public static int maxExp = 100;

    public static bool dead = false;

    public Canvas addPointCanvas;


    /*
    private int baseAttack = 20; //attack
    private float baseAgility = 2.5f; //speed
    private int baseStrength = 1000; //hp
    private int baseLevel = 1;
    private int baseMaxExp = 100;
    */

    public static int unusedPoint = 0;
    public static int attackPoint = 0;
    public static int agilityPoint = 0;
    public static int strengthPoint = 0;

    public Slider expSlider;
    public Text levelText;
    public Text pointText;


    private void Update()
    {
        if(unusedPoint > 0)
        {
            addPointCanvas.enabled = true;
        } else if (unusedPoint <= 0)
        {
            addPointCanvas.enabled = false;
        }
    }
    private void Awake()
    {
        /*
        attack = baseAttack;
        agility = baseAgility;
        strength = baseStrength;
        level = baseLevel;
        maxExp = baseMaxExp;

        currMaxHP = baseStrength;
        */
    }

    public void gainExp(int exp)
    {
        
        if (currExp + exp < maxExp)
        {
            currExp += exp;
        } else if (currExp + exp >= maxExp) 
        {
            levelUp((currExp + exp) - maxExp);
        }
        Debug.Log("gain exp, exp now = " + currExp);
        expSlider.value = currExp;
    }

    void levelUp(int sisaEXP)
    {
        //reset hp
        strength = currMaxHP;
        currExp = sisaEXP;

        unusedPoint += 1;
        maxExp += 20;
        level += 1;

        levelText.text = level.ToString();
        pointText.text = unusedPoint.ToString();
    }



     
}
