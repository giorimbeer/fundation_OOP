using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private int live = 100;

    public int actualLive;

    Enemy enemy;

    bool canBlock = true;

    bool canHeal = true;

    bool canAtack = true;

    bool canDoge = true;
    private void Start()
    {
        actualLive = live;
        enemy = GameObject.FindGameObjectWithTag("Enemy").GetComponent<Enemy>();
    }

    public void Heal()
    {
        actualLive += 1;
    }

    public void Atack()
    {
        
        
        if (canAtack) 
        {
            enemy.actualLive -= 1;
            print(enemy.actualLive);
        }
        
        StartCoroutine(Wait(10, canAtack));
        
    }

    public void Doge()
    {

    }

    public void Block()
    {

    }

    IEnumerator Wait(int seconds, bool can)
    {
        can = false;

        yield return new WaitForSeconds(seconds);
        
        can = true;
    }
}
