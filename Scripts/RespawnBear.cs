using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnBear : MonoBehaviour
{
    //enemy.GetComponent<BearStat>().bearCurrHP
    public GameObject bear;
    float interval;
    float deathTime;
    float currTime;

    private void Start()
    {
        interval = 5f;
        bear = gameObject; 
    }

    public void bearDie()
    {
        //catat waktu sekarang, utk menentukan waktu respawn
        this.deathTime = Time.time;
        // hide/deactivate
        this.bear.SetActive(false);
        // reset darah
        this.bear.GetComponent<BearStat>().bearCurrHP = this.bear.GetComponent<BearStat>().bearHP;
        Debug.Log("masuk bearDie, deathTime = " + deathTime);
    }
     
    private void Update()
    {
        this.currTime = Time.time;
        Debug.Log("curr time = " + this.currTime + " deathTime = " + this.deathTime + " interval = " + interval);
        if (currTime - deathTime > interval && deathTime != 0) {
            Debug.Log("masuk if currTime - deathTime > intervalllllllllllllllllllllllllllllllll");
            bear.SetActive(true);
        }
    }
}
