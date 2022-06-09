using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootSteps : MonoBehaviour
{
    // Start is called before the first frame update
     CharacterController characterControl;
    // Start is called before the first frame update
    void Start()
    {
        characterControl = GetComponent<CharacterController>();

    }

    // Update is called once per frame
    void Update()
    {
        if(characterControl.isGrounded && characterControl.velocity.magnitude > 0 && GetComponent<AudioSource>().isPlaying == false){
            GetComponent<AudioSource>().volume = Random.Range(0.8f, 1f);
            GetComponent<AudioSource>().pitch = Random.Range(0.8f,1.1f);
            GetComponent<AudioSource>().Play();
        }
    }
}
