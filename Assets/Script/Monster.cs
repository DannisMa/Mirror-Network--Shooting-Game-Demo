using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class Monster : Animal
{
    // Start is called before the first frame update
   public override void OnStartLocalPlayer()
    {
        hp = 1;
        atk = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public override void TakeDamage(int damage){
        hp -= damage;
        print("怪物剩餘血量:"+hp);
    }

    [Command]
    void changeHp(int damage){
        RpcChangeHp(damage);
    }
    [ClientRpc]
    void RpcChangeHp(int damage){
        hp -= damage;
    }
}
