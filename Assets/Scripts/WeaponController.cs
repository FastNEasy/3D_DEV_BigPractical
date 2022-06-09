using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    [SerializeField] GameObject Sword;
    [SerializeField] bool canAttack = true;
    [SerializeField] float attackCooldown = 1.0f;
    [SerializeField] AudioClip swordSwing;
    public bool isAttacking = false;
    AudioSource audioSrc;
    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = Sword.GetComponent<Animator>();
        audioSrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0)){
            if(canAttack){
                SwordAttack();
            }
        }
    }
    void SwordAttack(){
        isAttacking = true;
        canAttack = false;
        anim.SetTrigger("Attack");
        audioSrc.PlayOneShot(swordSwing);
        StartCoroutine(ResetAttackCooldown());
    }
    IEnumerator ResetAttackCooldown(){
        StartCoroutine(ResetAttackBool());
        yield return new WaitForSeconds(attackCooldown);
        canAttack = true;
    }
    IEnumerator ResetAttackBool(){
        yield return new WaitForSeconds(1.0f);
        isAttacking = false;
    }

}
