using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartLevel : MonoBehaviour
{
    [SerializeField] internal GameObject spawner;
    [SerializeField] internal GameObject deactivatable;
    // Start is called before the first frame update
   void OnTriggerEnter(Collider other){
       if(other.CompareTag("Player")){
            //GameManager.instance.levelStarted = true;
            deactivatable.SetActive(false);
            spawner.SetActive(true);
       }
   }
}
