using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    Gladiator _player;
    public Gladiator Player{
        get{
            if(_player == null) _player = FindObjectOfType<Gladiator>();
            return _player;
        }
    }

    //starts to spawn only when user jumps on the arena
    public bool levelStarted { get; set;}
    public bool overTime { get; set;}

    void Awake(){
        levelStarted = false;
        overTime = false;
        if(instance == null) instance = this;
        else Destroy(gameObject);
    }
}
