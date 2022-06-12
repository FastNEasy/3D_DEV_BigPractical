using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gladiator : Character
{
    PlayerMotionController _playerController;
    CharacterController _characterController;
    [SerializeField] AudioSource _hitSrc;
    [SerializeField] float _receivedDamage = 20f;
    [SerializeField] float damageOvertime = 5f;
    [SerializeField] Slider _healthSlider;
    [SerializeField] GameObject _deadScreen;
    WeaponController _wepController;
    protected override void Start(){
        base.Start();
        _playerController = GetComponent<PlayerMotionController>();
        _characterController = GetComponent<CharacterController>();
        _wepController = GetComponentInChildren<WeaponController>();
    }
      
    // public override void AddDamage(float damage){
    //     base.AddDamage(damage);
    //     if(isDead){

    //     }
    // }
    void Update(){
        if(GameManager.instance.overTime){
            ApplyTimedDamage();
        }
    }
    void ApplyTimedDamage(){
        AddDamage(damageOvertime * Time.deltaTime * 1);
    }
    protected override void Die(){
        base.Die();
        Debug.Log("You died");
        _playerController.enabled = false;
        _characterController.enabled = false;
        _wepController.enabled = false;
        _deadScreen.SetActive(true);
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;

    }
    void OnTriggerEnter(Collider other){
        if(other.CompareTag("EnemyWeapon")){
            _hitSrc.Stop();
            Debug.Log("I got hit! My health:" + health);
            _hitSrc.Play();
            AddDamage(_receivedDamage);
        }
    }
    protected override void UpdateHealth()
    {
        base.UpdateHealth();
        _healthSlider.value = HealthPercent;
    }
}
