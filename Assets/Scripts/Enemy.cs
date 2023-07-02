using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;


//father class of the enemies
public class Enemy : MonoBehaviour
{
    protected Player player;

    //vars for the texts in screen
    protected TextMeshProUGUI text; //text of damage
    protected TextMeshProUGUI liveText;

    //vars for the live of the enemy
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
    private int backupLive = 3;
    public  int actualLive;

    //vars for the damage
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
    private int backupDamage = 5;


    //var for the cooldown of the habilities
    protected bool canAccion = true;


    //protected bool canShow = false;

    
    private void Start()
    {

        //allocation of vars
        actualLive = backupLive;

        text = GameObject.Find("TextEnemies").GetComponent<TextMeshProUGUI>();

        liveText = GameObject.Find("TextEnemiesLive").GetComponent<TextMeshProUGUI>();
       
        player = GameObject.Find("Player").transform.GetComponent<Player>();

        //allocation of state of text
        text.enabled = false;

        
    }

    private void Update()
    {
        //show live
        liveText.text = "Enemy Live: " + actualLive;
        if(liveText.text.Contains("-")) liveText.text = "Enemy Live: 0";

        //allow accion
        if (canAccion)
        {
            Action();
        }

        //view the state of the enemy
        Death();
    }

    //skil to execute
    public virtual void Action()
    {

        StartCoroutine(SpawnText());
        StartCoroutine(CoolDown());
    }

    //manage of the death
    protected virtual void Death()
    {
        if (actualLive <= 0)
        {
            player.readDamageEnemy = true;
            Destroy(gameObject);
            actualLive = live;
            text.enabled = false;
        }
    }

    //timer for do the action/skill
    public IEnumerator CoolDown()
    {
        canAccion = false;
        yield return new WaitForSeconds(3);
        canAccion = true;
    }

    //timer for show a quit the text of damage
    public IEnumerator SpawnText()
    {
        text.enabled = true;
        yield return new WaitForSeconds(1.5f);
        text.enabled = false;
    }
}
