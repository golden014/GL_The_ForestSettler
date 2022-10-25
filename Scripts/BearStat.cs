using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class BearStat : MonoBehaviour
{
    public Animator bearAnimator;
    public static int bearAttack = 30;
    public int bearCurrHP = 100;
    public int bearHP = 100;
    public int bearEXP = 0;
    public static int expEarned = 35;
    public AudioSource deathSound;

    public Slider bearHPSlider;

    public bool isAlive = true;

    private void Start()
    {
        bearAnimator = GetComponent<Animator>();
    }

    public void bearDeath()
    {
        deathSound.Play();
        Debug.Log("ini bear death :D");
        bearAnimator.SetBool("Death", true);
    }

    public void updateHP()
    {
        bearHPSlider.value = bearCurrHP;
    }

}
