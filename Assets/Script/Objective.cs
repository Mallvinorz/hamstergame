using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Objective : MonoBehaviour
{
    // Start is called before the first frame update
    int score = 0;
    private void OnCollisionEnter(Collision collision) {
        if(collision.gameObject.tag == "Fish"){
         SetScore(score += 1);//set score ketika player collide dengan objek dg tag Fish
        }
    }
    private void SetScore(int num){
        score = num;
    }
    public int GetScore(){
        return score;//mengembalikan nilai score
    }
}
