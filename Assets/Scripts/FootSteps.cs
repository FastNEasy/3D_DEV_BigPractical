using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootSteps : MonoBehaviour
{
    // Start is called before the first frame update
     CharacterController characterControl;
     AudioSource audioSrc;
    // Start is called before the first frame update
    void Start()
    {
        characterControl = GetComponent<CharacterController>();
        audioSrc = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        if(characterControl.isGrounded && characterControl.velocity.magnitude > 0 && !audioSrc.isPlaying){
            audioSrc.volume = Random.Range(0.8f, 1f);
            audioSrc.pitch = Random.Range(0.8f,1.1f);
            audioSrc.Play();
        }
    }
}
