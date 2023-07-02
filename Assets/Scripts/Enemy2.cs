using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2 : Enemy
{
    bool can = true;
    public override void Action()
    {
        if(can) actualLive += 5;

        can = false;

        text.text = "daño sufrido " + damage;
        player.actualLive -= damage;

        base.Action();
    }
    protected override void Death()
    {
        if(actualLive <= 0)
        {
            base.Death();

            text.text = "daño sufrido " + damage * 2; 
            player.actualLive -= damage * 2;
            text.enabled = true;
        }  
    }  
}
