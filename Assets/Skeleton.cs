using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Skeleton : Character
{
    //TODO: states with animations of fighting
    //if distance greater than 10 enter running
    //if distance 0.1 - 1.5 do a swing
    //if 3 swings done, do a special swing
    //if distance closer than 10, enter walk mode
    //if health reaches 0, die
    private Animator _animator;
    private NavMeshAgent _navmeshAgent;
    private bool isAttacking = false;
    private bool isWalking = false;
    private bool isRunning = false;
    void Start(){
        _animator = GetComponentInChildren<Animator>();
        _navmeshAgent = GetComponent<NavMeshAgent>();
        _navmeshAgent.isStopped = true;
        //_animator.SetBool("isWalking", true);
    }
    void Update(){
        Vector3 playerPos = GameManager.instance.Player.transform.position;
        float distToPlayer = Vector3.Distance(transform.position, playerPos);
        Debug.Log("Enemy Distance: " + distToPlayer);
        //transform.LookAt(playerPos, Vector3.up);
        if(distToPlayer <= 2.5f){
            Debug.Log("Attacking player ");
            _navmeshAgent.isStopped = true;
            _navmeshAgent.speed = 0f;
            isAttacking = true;
            isWalking = false;
            _animator.SetBool("isAttacking", isAttacking);
            _animator.SetBool("isWalking", isWalking);
        }else if(distToPlayer > 2.5f && distToPlayer < 5f){
            Debug.Log("Walking to player");
            _navmeshAgent.SetDestination(playerPos);
            _navmeshAgent.isStopped = false;
            _navmeshAgent.speed = 0.5f;
            isAttacking = false;
            isWalking = true;
            isRunning = false;
            _animator.SetBool("isAttacking", isAttacking);
            _animator.SetBool("isWalking", isWalking);
            _animator.SetBool("isRunning", isRunning);
        } else{
            Debug.Log("Running to player");
            _navmeshAgent.SetDestination(playerPos);
            _navmeshAgent.isStopped = false;
            _navmeshAgent.speed = 3f;
            isAttacking = false;
            isWalking = false;
            isRunning = true;
            _animator.SetBool("isAttacking", isAttacking);
            _animator.SetBool("isWalking", isWalking);
            _animator.SetBool("isRunning", isRunning);
        }

    }
}
