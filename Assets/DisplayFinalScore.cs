using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DisplayFinalScore : MonoBehaviour
{
    public TextMeshProUGUI finalScoreText;
    string finalScoreStr = Score.Instance.scoreStr;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        finalScoreText.text = "You Scored: " + finalScoreStr;
    }
}
