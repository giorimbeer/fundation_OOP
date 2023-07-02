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
    private int live = 100;

    public int actualLive;

    Enemy enemy;

    bool canBlock = true;

    bool canHeal = true;

    bool canAtack = true;

    bool canDoge = true;

    //bottons
    public Image buttonAtack;
    public Image buttonHeal;
    public Image buttonDoge;
    public Image buttonBlock;

    public TextMeshProUGUI timeAtack;
    public TextMeshProUGUI timeHeal;

    public TextMeshProUGUI actionsPlayerText;

    public TextMeshProUGUI livePlayerText;


    public bool readDamageEnemy = true;

    int damageEnemy;

    int damagePlayer = 2;

    int heal = 5;

    private void Start()
    {
        actualLive = live;
        actionsPlayerText.enabled = false;
    }

    private void Update()
    {
        livePlayerText.text = "live: " + actualLive;
    }

    public void Heal()
    {
        if (canHeal)
        {
            actionsPlayerText.text = "damage heal: " + heal;
            StartCoroutine(SpawnText());
            StartCoroutine(WaitHeal(30));
            actualLive += heal;
           
        }
        
    }

    public void Atack()
    {
        if(enemy == null)  enemy = GameObject.FindGameObjectWithTag("Enemy").GetComponent<Enemy>();

        if (readDamageEnemy) damageEnemy = enemy.damage;

        if (canAtack) 
        {
            actionsPlayerText.text = "damage made: " + damagePlayer;
            StartCoroutine(SpawnText());
            enemy.actualLive -= damagePlayer;
            StartCoroutine(WaitAtack(3.5f));
        }       
    }

    public void Doge()
    {       
        int damageEnemyBackup = EnemyDamage();

        if (canDoge)
        {
            StartCoroutine(WaitDoge(10));
            StartCoroutine(Action(damageEnemyBackup * 0));
        }
    }

    public void Block()
    {
        int damageEnemyBackup = EnemyDamage();

        if (canBlock)
        {
            StartCoroutine(WaitBlock(5));
            StartCoroutine(Action( damageEnemyBackup / 3));
        }
    }

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

    //IEnumerator Count(int wait, TextMeshProUGUI text)
    //{
    //    text.enabled = true;
    //    for (int i = 0; i < wait+1; i++)
    //    {
    //        text.text = i.ToString();
    //        yield return new WaitForSeconds(1);
    //    }
    //    text.enabled = false;
    //}

    //void Count(int wait, TextMeshProUGUI text)
    //{
    //    float seg = 0;

    //    if(seg <= Time.time && seg <= wait)
    //    {
    //        seg += Time.time;
    //        text.text = seg.ToString();
    //    }
    //}

    IEnumerator SpawnText()
    {
        actionsPlayerText.enabled = true;
        yield return new WaitForSeconds(1.5f);
        actionsPlayerText.enabled = false;
    }

    IEnumerator Action(int num)
    {      
        enemy.damage = num;
        print(enemy.damage);
        yield return new WaitForSeconds(3);
        enemy.damage = damageEnemy;
        print(enemy.damage);
    }

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
}
