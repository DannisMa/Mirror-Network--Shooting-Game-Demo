using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : Animal
{
    // Start is called before the first frame update
    void Start()
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
}
