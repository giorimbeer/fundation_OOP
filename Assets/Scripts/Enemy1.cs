using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//child of enemy
public class Enemy1 : Enemy
{  
    public override void Action()
    {
        text.text = "da�o sufrido " + damage;
        player.actualLive -= damage;

        base.Action();
    }
}
