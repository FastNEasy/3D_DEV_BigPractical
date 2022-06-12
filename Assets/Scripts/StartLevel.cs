using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class StartLevel : MonoBehaviour
{
    [SerializeField] internal GameObject spawner;
    [SerializeField] internal GameObject deactivatable;
    [SerializeField] internal GameObject activatable;
    [SerializeField] internal GameObject activatableText;

    
   void OnTriggerEnter(Collider other){
       if(other.CompareTag("Player")){
            //starts the timer countdown
            GameManager.instance.levelStarted = true;
            deactivatable.SetActive(false);
            activatable.SetActive(true);
            activatableText.SetActive(true);
            spawner.SetActive(true);
            Debug.Log(GameManager.instance.levelStarted);
       }
   }
   
}
