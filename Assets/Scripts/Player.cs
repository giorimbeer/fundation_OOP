using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Runtime.Serialization;
using System;
using Unity.VisualScripting;

public class Player : MonoBehaviour
{
    Enemy enemy;

    //vars of life
    private int live = 100;
    public int actualLive;
    int heal = 5;

    //vars for allow the execution of the skills
    bool canBlock = true;
    bool canHeal = true;
    bool canAtack = true;
    bool canDoge = true;

    // look of the bottons of skills
    public Image buttonAtack;
    public Image buttonHeal;
    public Image buttonDoge;
    public Image buttonBlock;

    //timer of the skills
    public TextMeshProUGUI timeAtack;
    public TextMeshProUGUI timeHeal;
    public TextMeshProUGUI timeBlock;
    public TextMeshProUGUI timeDoge;

    //texts
    public TextMeshProUGUI actionsPlayerText;
    public TextMeshProUGUI livePlayerText;

    //vars of damage
    int damagePlayer = 2;

    int damageEnemy;
    public bool readDamageEnemy = true;


    private void Awake()
    {
        actualLive = live;
        actionsPlayerText.enabled = false;

        //hide timers
        timeAtack.enabled = false;
        timeHeal.enabled = false;
        timeBlock.enabled = false;
        timeDoge.enabled = false;
    }

    private void Update()
    {
        //show life
        livePlayerText.text = "live: " + actualLive;
    }


    //methos for the skills
    public void Heal()
    {
        if (canHeal)
        {
            actionsPlayerText.text = "damage heal: " + heal;
            StartCoroutine(SpawnText());
            StartCoroutine(WaitHeal(30));
            StartCoroutine(Count(30, timeHeal));
            actualLive += heal;
           
        }
        
    }

    public void Atack()
    {
        //serch enemy 
        if(enemy == null)  enemy = GameObject.FindGameObjectWithTag("Enemy").GetComponent<Enemy>();
        if (readDamageEnemy) damageEnemy = enemy.damage;

        //skill
        if (canAtack) 
        {
            actionsPlayerText.text = "damage made: " + damagePlayer;
            StartCoroutine(SpawnText());
            enemy.actualLive -= damagePlayer;
            StartCoroutine(WaitAtack(3.5f));
            StartCoroutine(Count(3, timeAtack));
        }       
    }

    public void Doge()
    {       
        int damageEnemyBackup = EnemyDamage();

        if (canDoge)
        {
            StartCoroutine(WaitDoge(10));
            StartCoroutine(Action(damageEnemyBackup * 0));
            StartCoroutine(Count(10, timeDoge));
        }
    }

    public void Block()
    {
        int damageEnemyBackup = EnemyDamage();

        if (canBlock)
        {
            StartCoroutine(WaitBlock(5));
            StartCoroutine(Action( damageEnemyBackup / 3));
            StartCoroutine(Count(5, timeBlock));
        }
    }


    //function for serch and select the enemy ans its damage
    int EnemyDamage()
    {
        if (enemy == null)
        {
            enemy = GameObject.FindGameObjectWithTag("Enemy").GetComponent<Enemy>();
            damageEnemy = enemy.damage;
            readDamageEnemy = false;
            return damageEnemy;
        }
        else 
            return damageEnemy;
    }

    //timer for show the action of the player
    IEnumerator SpawnText()
    {
        actionsPlayerText.enabled = true;
        yield return new WaitForSeconds(1.5f);
        actionsPlayerText.enabled = false;
    }

    //function to manipulate the damge of the enemy
    IEnumerator Action(int num)
    {
        enemy.damage = num;
        yield return new WaitForSeconds(3);
        enemy.damage = damageEnemy;
    }

    //functions for skill cooldown
    IEnumerator WaitAtack(float seconds)
    {
        buttonAtack.color = Color.grey;
        canAtack = false; 
        yield return new WaitForSeconds(seconds);
        canAtack = true;
        buttonAtack.color = Color.white;
    }

    IEnumerator WaitBlock(float seconds)
    {
        buttonBlock.color = Color.gray;
        canBlock = false;
        yield return new WaitForSeconds(seconds);
        canBlock = true;
        buttonBlock.color = Color.white;
    }

    IEnumerator WaitDoge(float seconds)
    {
        buttonDoge.color = Color.gray;
        canDoge = false;
        yield return new WaitForSeconds(seconds);
        canDoge = true;
        buttonDoge.color = Color.white;
    }

    IEnumerator WaitHeal(float seconds)
    {
        buttonHeal.color = Color.gray;
        canHeal = false;
        yield return new WaitForSeconds(seconds);
        canHeal = true;
        buttonHeal.color = Color.white;
    }

    //timer to show
    IEnumerator Count(int wait, TextMeshProUGUI text)
    {
        text.enabled = true;
        for (int i = 1; i < wait + 1; i++)
        {
            text.text = i.ToString();
            yield return new WaitForSeconds(1);
        }
        text.enabled = false;
    }

}
