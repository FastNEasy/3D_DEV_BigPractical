using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gladiator : Character
{
    PlayerMotionController _playerController;
    private void Start(){
        _playerController = GetComponent<PlayerMotionController>();
    }
    // void AddDamage(float damage){
    //    health -= damage;
    //    if(health <= 0){
    //        Die();
    //    }
      
    // }
    protected override void Die(){
        base.Die();
        _playerController.enabled = false;
    }
}
