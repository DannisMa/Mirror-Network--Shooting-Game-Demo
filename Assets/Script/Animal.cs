using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
public class Animal : NetworkBehaviour
{
    [SyncVar(hook = nameof(OnHpChange))]
    protected int hp;
    protected int atk;
    protected float moveSpeed;
    
    public virtual void TakeDamage(int damage){}
    void OnHpChange(int _Old, int _New)
    {
        hp = _New;
    }
}
