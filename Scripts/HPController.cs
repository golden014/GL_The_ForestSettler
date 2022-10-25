using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPController : MonoBehaviour
{

    public GameObject unityChan;
    public SliderController HPSlider;
    private float delayInSeconds = 0;
    private float delayInSeconds2 = 0;
  //  public AudioSource dieSound;

    private static Animator animator;

    private void Start()
    {
 
        animator = GetComponent<Animator>();

    }

    private void Update()
    {
        if(Cursor.visible)
        {
            return;
        }
        GameObject[] listEnemies = GameObject.FindGameObjectsWithTag("Bear");
        GameObject[] listEnemiesWolf = GameObject.FindGameObjectsWithTag("Wolf");

        foreach(GameObject enemy in listEnemies)
        {

            if (enemy && Vector3.Distance(enemy.transform.position, unityChan.transform.position) < 3 && playerStat.dead == false && enemy.GetComponent<BearStat>().isAlive == true)
            {
                Debug.Log("masuk area menyerang");
                if (Input.GetMouseButtonDown(0))
                { 
                    Debug.Log("menyerang bear");
                    //HP
                    //enemy.hp -= 10;
                    //enemy.GetComponent<In>
                    if (enemy.GetComponent<BearStat>().bearCurrHP - playerStat.attack > 0)
                    {
                        enemy.GetComponent<BearStat>().bearCurrHP -= playerStat.attack;
                        enemy.GetComponent<BearStat>().updateHP();
                    } else if (enemy.GetComponent<BearStat>().bearCurrHP - playerStat.attack <= 0)
                    {
                        enemy.GetComponent<BearStat>().bearCurrHP = 0;
                        enemy.GetComponent<BearStat>().isAlive = false;
                        enemy.GetComponent<BearStat>().bearDeath();
                        enemy.GetComponent<BearStat>().updateHP();
                        unityChan.GetComponent<playerStat>().gainExp(BearStat.expEarned);
                    }
                }

                if (delayInSeconds >= 2)
                {
                    enemy.GetComponent<Animator>().SetBool("Attack1", true);
                    delayInSeconds = 0;
                }
                delayInSeconds += Time.deltaTime;
        
            } else
            {
                enemy.GetComponent<Animator>().SetBool("Attack1", false);
                enemy.GetComponent<Animator>().SetBool("WalkForward", true);
            }
        }

        foreach (GameObject enemy in listEnemiesWolf)
        {

            if (enemy && Vector3.Distance(enemy.transform.position, unityChan.transform.position) < 3 && playerStat.dead == false && enemy.GetComponent<WolfStat>().isAlive == true)
            {
                Debug.Log("masuk area menyerang wolfffffffff");
                if (Input.GetMouseButtonDown(0))
                {
                    Debug.Log("menyerang bear");
                    //HP
                    //enemy.hp -= 10;
                    //enemy.GetComponent<In>
                    if (enemy.GetComponent<WolfStat>().bearCurrHP - playerStat.attack > 0)
                    {
                        enemy.GetComponent<WolfStat>().bearCurrHP -= playerStat.attack;
                        enemy.GetComponent<WolfStat>().updateHP();
                    }
                    else if (enemy.GetComponent<WolfStat>().bearCurrHP - playerStat.attack <= 0)
                    {
                        enemy.GetComponent<WolfStat>().bearCurrHP = 0;
                        enemy.GetComponent<WolfStat>().isAlive = false;
                        enemy.GetComponent<WolfStat>().wolfDeath();
                        enemy.GetComponent<WolfStat>().updateHP();
                        unityChan.GetComponent<playerStat>().gainExp(WolfStat.expEarned);
                    }
                }

                if (delayInSeconds2 >= 2)
                {
                    Debug.Log("masuk delayy wolff" + enemy.GetComponent<Animator>().GetBool("Attack").ToString());
                    enemy.GetComponent<Animator>().SetBool("Attack", true);
                    delayInSeconds2 = 0;
                }
                delayInSeconds2 += Time.deltaTime;

            }
            else
            {
                enemy.GetComponent<Animator>().SetBool("Attack", false);
                enemy.GetComponent<Animator>().SetBool("WalkForward", true);
            }
        }

    }

    public static void die()
    {
        animator.SetTrigger("Die");
        
       
    }

}
