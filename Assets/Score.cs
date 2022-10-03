using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    // Start is called before the first frame update
    public Objective objective;
    [SerializeField] TextMeshProUGUI m_ScoreText;//reference ke text mesh pro
    // Update is called once per frame
    void Update()
    {
        m_ScoreText.text = objective.GetScore().ToString();//update score ke text score
    }
}
