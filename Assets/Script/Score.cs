using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    // Start is called before the first frame update
    public Objective objectivePlayer;
    [SerializeField] TextMeshProUGUI m_ScoreText;//reference ke text mesh pro
    // Update is called once per frame
    int totalFish;
    private void Start() {
        totalFish = GameObject.FindGameObjectsWithTag("Fish").Length;
    }
    void Update()
    {
        m_ScoreText.text = objectivePlayer.GetScore().ToString() + "/" + totalFish;//update score ke text score
    }
}
