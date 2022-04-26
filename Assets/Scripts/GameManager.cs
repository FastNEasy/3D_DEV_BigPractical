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

    void Awake(){
        if(instance == null) instance = this;
        else Destroy(gameObject);
    }
}
