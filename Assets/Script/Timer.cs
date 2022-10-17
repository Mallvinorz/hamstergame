using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public int timerInSecond;
    public int blinkSpeed = 10;
    [SerializeField] TextMeshProUGUI timerText;
    float timeLeft;
    bool timerOn = true;
    int minute, second;
    string secondStr, minuteStr;

    public GameOver gameOver;
    public Objective objective;
    // Start is called before the first frame update
    void Start()
    {
        timeLeft = (float)timerInSecond;
    }

    // Update is called once per frame
    void Update()
    {
        if(objective.GetIsAllCollected()){
            gameOver.GameOverOn();
            return;
        } 
        
        if(timerOn){
            if(timeLeft > 0){
                timeLeft -= Time.deltaTime;
            }else{
                timeLeft = 0;
                timerOn = false;
                gameOver.GameOverOn();
            }

            
            minute = (int)Mathf.Floor(timeLeft/60);
            second = (int)Mathf.Floor(timeLeft%60);
            minuteStr = minute < 10? "0" + minute.ToString() : minute.ToString();
            secondStr = second < 10? "0" + second.ToString() : second.ToString();

            timerText.text = minuteStr + ":" + secondStr;
            if(timeLeft < 10) timerText.color = new Color(255,255,255,(Mathf.Sin(Time.time * blinkSpeed)));
        }
    }
}
