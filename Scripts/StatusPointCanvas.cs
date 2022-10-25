using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class StatusPointCanvas : MonoBehaviour
{
    public Text currPoint;
    public Text agiText;
    public Text strText;
    public Text powText;
    public Text maxHPValue;

    public void addAgility()
    {
        playerStat.agility += 2f;
        playerStat.agilityPoint += 1;
        playerStat.unusedPoint -= 1;

        agiText.text = playerStat.agilityPoint.ToString();
        updateAvailPoint();
    }
    public void addStrength()
    {
        playerStat.currMaxHP += 150;
        //reset hp setelah di tambahin
        playerStat.strength = playerStat.currMaxHP;

        playerStat.strengthPoint += 1;
        playerStat.unusedPoint -= 1;

        maxHPValue.text = "/ " + playerStat.currMaxHP.ToString();
        strText.text = playerStat.strengthPoint.ToString();
        updateAvailPoint();
    }

    public void addAttack()
    {
        playerStat.attack += 5;

        playerStat.attackPoint += 1;
        playerStat.unusedPoint -= 1;

        powText.text = playerStat.attackPoint.ToString();
        updateAvailPoint();

    }

    public void updateAvailPoint()
    {
        currPoint.text = playerStat.unusedPoint.ToString();
    }
}
