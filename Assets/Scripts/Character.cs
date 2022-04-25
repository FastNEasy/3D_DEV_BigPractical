using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MonoBehaviour
{
    protected float health = 100;
    protected bool isDead = false;
    void AddDamage(float damage){
       health -= damage;
       if(health <= 0){
           Die();
       }
      
    }
    protected virtual void Die(){
        if(isDead) return;
        isDead = true;
    }
}
