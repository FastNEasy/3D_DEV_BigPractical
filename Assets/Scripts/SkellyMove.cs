using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SkellyMove : MonoBehaviour
{
    NavMeshAgent _navmeshAgent;
    SkeletonAI _aIScript;
    AudioSource _audioSrc;
    private float walkDelay = 0.15f;
    // Start is called before the first frame updat
    void Start(){
        _navmeshAgent = GetComponentInParent<NavMeshAgent>();
        _audioSrc = GetComponent<AudioSource>();
        _aIScript = GetComponentInParent<SkeletonAI>();
    }
    // Update is called once per frame
    void Update()
    {
        if(!_audioSrc.isPlaying){
            StartCoroutine(walkSound());
        }
        if(_aIScript.turnOffWalk){
            _audioSrc.enabled = false;
        }
       
    }
    IEnumerator walkSound(){
       
        yield return new WaitForSeconds(walkDelay);
         _audioSrc.volume = Random.Range(0.5f, 0.8f);
         _audioSrc.pitch = Random.Range(0.8f,1.0f);
        _audioSrc.Play();
    }
}
