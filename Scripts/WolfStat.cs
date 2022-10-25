using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class WolfStat : MonoBehaviour
{
    public Animator wolfAnimator;
    public static int bearAttack = 50;
    public int bearCurrHP = 70;
    public int bearHP = 70;
    public int bearEXP = 0;
    public static int expEarned = 25;

    public Slider bearHPSlider;

    public bool isAlive = true;
    public AudioSource deathSound;

    private void Start()
    {
        wolfAnimator = GetComponent<Animator>();
    }

    public void wolfDeath()
    {
        Debug.Log("ini bear death :D");
        wolfAnimator.SetBool("Death", true);
        deathSound.Play();
    }

    public void updateHP()
    {
        bearHPSlider.value = bearCurrHP;
    }
}
