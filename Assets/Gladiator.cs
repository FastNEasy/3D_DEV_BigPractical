using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gladiator : Character
{
    PlayerMotionController _playerController;
    [SerializeField] float _receivedDamage = 20f;
    [SerializeField] Slider _healthSlider;
    protected override void Start(){
        base.Start();
        _playerController = GetComponent<PlayerMotionController>();
    }
      
    // public override void AddDamage(float damage){
    //     base.AddDamage(damage);
    //     if(isDead){

    //     }
    // }
    protected override void Die(){
        base.Die();
        Debug.Log("You died");
        _playerController.enabled = false;
    }
    void OnTriggerEnter(Collider other){
        if(other.CompareTag("EnemyWeapon")){
            Debug.Log("I got hit! My health:" + health);
            AddDamage(_receivedDamage);
        }
    }
    protected override void UpdateHealth()
    {
        base.UpdateHealth();
        _healthSlider.value = HealthPercent;
    }
}
