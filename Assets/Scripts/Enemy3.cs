using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy3 : Enemy
{
    public override void Action()
    {
        text.text = "daño sufrido " + damage;
        player.actualLive -= damage;

        if (Random.Range(0,11) >= 8) actualLive +=3;

        base.Action();
    }
}
