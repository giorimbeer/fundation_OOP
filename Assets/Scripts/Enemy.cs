using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;

public class Enemy : MonoBehaviour
{
    protected Player player;
    protected TextMeshProUGUI text;
    protected TextMeshProUGUI liveText;

    private int backupLive = 3;
    private int backupDamage = 5;

    public int live
    {
        get => backupLive;
        set 
        { 
            if (value < 3)
            {
                Debug.LogWarning("the live can't be less that three");
                
            }
            else backupLive = value;
        }
    }

    public  int actualLive;

    public int damage
    {
        get => backupDamage;
        set
        {
            if (value < 0)
            {
                
                Debug.LogWarning("the damage can't be less that zero");

            }
            else backupDamage = value;
        }
    }

    protected bool canAccion = true;
    protected bool canShow = false;

    
    private void Awake()
    {
        actualLive = backupLive;

        text = GameObject.Find("TextEnemies").GetComponent<TextMeshProUGUI>();

        liveText = GameObject.Find("TextEnemiesLive").GetComponent<TextMeshProUGUI>();

        try{
            player = GameObject.Find("Player").transform.GetComponent<Player>();
        }catch(Exception e)
        {
            print(e.ToString());
        }

    }

    private void Update()
    {
        liveText.text = "Enemy Live: " + actualLive;

        if(liveText.text.Contains("-")) liveText.text = "Enemy Live: 0";

        if (canAccion)
        {
            Action();
        }

        Death();
    }

    public virtual void Action()
    {
        StartCoroutine(SpawnText());
        StartCoroutine(CoolDown());
    }

    protected virtual void Death()
    {
        if (actualLive <= 0)
        {

            Destroy(gameObject);
        }
    }

    public IEnumerator CoolDown()
    {
        canAccion = false;
        yield return new WaitForSeconds(3);
        canAccion = true;
    }

    public IEnumerator SpawnText()
    {
        text.enabled = true;
        yield return new WaitForSeconds(1.5f);
        text.enabled = false;
    }
}
