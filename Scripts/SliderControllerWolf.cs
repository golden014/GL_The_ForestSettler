using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class SliderControllerWolf : MonoBehaviour
{
    [SerializeField]
    public Text valueHP;

    [SerializeField]
    public Text valueMaxHP;


    [SerializeField]
    public Slider HPSlider;

    public AudioSource dieSound;

    public Animator bearAnimator;

    /*
    public static int bearAttack = 10;
    public static int bearCurrHP = 100;
    public static int bearHP = 100;
    */
    // public static 

    public void onHitHP()
    {

        if ((playerStat.strength - WolfStat.bearAttack) <= 0 && playerStat.dead == false)
        {
            playerStat.dead = true;
            playerStat.strength = 0;
            dieSound.Play();
            HPController.die();
            bearAnimator.SetBool("Attack1", true);
        }
        else if ((playerStat.strength - WolfStat.bearAttack) > 0 && playerStat.dead == false)
        {
            playerStat.strength -= WolfStat.bearAttack;
        }

        if (playerStat.dead == true)
        {
            bearAnimator.SetBool("Attack1", false);
            // bearAnimator.SetBool("WalkForward", true);
        }

        HPSlider.value = playerStat.strength;
        valueHP.text = playerStat.strength.ToString();

    }

}
