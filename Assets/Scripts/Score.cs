using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    public static Score Instance;

    public TextMeshProUGUI scoreTMP;
    public GameObject scoreTextObj;
    public int score = 0;
    public string scoreStr;
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        scoreTextObj = GameObject.FindWithTag("ScoreText");
        scoreTMP = scoreTextObj.GetComponent<TextMeshProUGUI>();

        scoreStr = score.ToString();
        scoreTMP.text = "Score: " + scoreStr;
    }
}
