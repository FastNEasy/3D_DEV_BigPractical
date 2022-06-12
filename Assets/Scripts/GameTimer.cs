using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameTimer : MonoBehaviour
{
    [SerializeField] internal Text timerText;
    float timeLeft = 60f;
    bool timerGoing = false;
    // Start is called before the first frame update
    void Start()
    {
        timerGoing = GameManager.instance.levelStarted;
    }

    // Update is called once per frame
    void Update()
    {
        // if(GameManager.instance.levelStarted){
        //     timerGoing = true;
        // }
        // Debug.Log("Level is: " + timerGoing);
       if (timerGoing)
        {
            if (timeLeft > 0)
            {
                timeLeft -= Time.deltaTime;
                DisplayTime(timeLeft);
            }
            else
            {
                Debug.Log("Time has run out!");
                timeLeft = 0;
                timerGoing = false;
                timerText.color = Color.red;
            }
        }
    }
    void DisplayTime(float displayedTime){
        displayedTime += 1;
        float minutes = Mathf.FloorToInt(displayedTime / 60); 
        float seconds = Mathf.FloorToInt(displayedTime % 60);
        timerText.text = "Beat them before: " + string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
