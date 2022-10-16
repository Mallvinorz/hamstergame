using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Objective : MonoBehaviour
{
    // Start is called before the first frame update
    int score = 0;
    bool isAllCollected = false;
    
    private void OnCollisionEnter(Collision collision) {
        if(collision.gameObject.tag == "Fish"){
         SetScore(score += 1);//set score ketika player collide dengan objek dg tag Fish
        }
    }
    public void SetScore(int num){
        score = num;
    }
    public int GetScore(){
        return score;//mengembalikan nilai score
    }

    public void SetIsAllCollected(bool arg){
        isAllCollected = arg;
    }

    public bool GetIsAllCollected(){
        return isAllCollected;
    }
    private void Update() {
        int fishLeft = GameObject.FindGameObjectsWithTag("Fish").Length;
        if(fishLeft == 0) SetIsAllCollected(true);
    }
}
