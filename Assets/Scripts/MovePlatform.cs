using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlatform : MonoBehaviour
{
    [SerializeField] float speed = 0.25f;

    private bool isOnLift = false;
 
    [SerializeField] Transform endPos;


    void Update(){
        if(isOnLift){
            if(transform.position != endPos.position){
                LerpPosition();  
            }
        }
       
    }
  
    void LerpPosition(){
        transform.position = Vector3.Lerp(transform.position, endPos.position, speed * Time.deltaTime);
    }
    void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Player")){
            isOnLift = true;
        }
    }
    void OnTriggerExit(Collider other){
        if(other.CompareTag("Player")){
            Destroy(gameObject);
        }
    }
}
