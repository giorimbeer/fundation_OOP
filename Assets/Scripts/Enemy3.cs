using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//child of enemy
public class Enemy3 : Enemy
{
    public override void Action()
    {
        text.text = "daño sufrido " + damage;
        player.actualLive -= damage;

        //add a chance of heal every time thet atack
        if (Random.Range(0,11) >= 8) actualLive +=3;

        base.Action();
    }
}
