using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderController : MonoBehaviour
{
    [SerializeField]
    public Text valueHP;
    [SerializeField]
    int remainingHP = 100;
    [SerializeField]
    public Slider HPSlider;

    public Animator playerAnimator;

    public void onHitHP()
    {
        remainingHP -= 10;

        if (remainingHP <= 0) HPController.die();
        HPSlider.value = remainingHP;
        valueHP.text = remainingHP.ToString();
        
    }

}
