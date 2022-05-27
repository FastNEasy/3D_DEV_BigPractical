using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    [SerializeField] GameObject Sword;
    [SerializeField] bool canAttack = true;
    [SerializeField] float attackCooldown = 1.0f;
    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = Sword.GetComponent<Animator>();
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
        canAttack = false;
        anim.SetTrigger("Attack");
        StartCoroutine(ResetAttackCooldown());
    }
    IEnumerator ResetAttackCooldown(){
        yield return new WaitForSeconds(attackCooldown);
        canAttack = true;
    }

}
