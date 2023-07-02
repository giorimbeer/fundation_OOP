using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//child of enemy
public class Enemy2 : Enemy
{
    //var for allow increment of life
    bool can = true;
    public override void Action()
    {
        if (can)
        {
            actualLive += 5;
            can = false;
        }
            
        //mesaje to show and action to do
        text.text = "daño sufrido " + damage;
        player.actualLive -= damage;

        base.Action();
    }
    protected override void Death()
    {
        if(actualLive <= 0)
        {
            base.Death();

            //BOOM! 
            text.text = "daño sufrido " + damage * 2; 
            player.actualLive -= damage * 2;
            text.enabled = true;
        }  
    }  
}
