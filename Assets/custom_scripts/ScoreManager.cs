using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 
using TMPro; 

public class ScoreManager: MonoBehaviour
{
    public static int score;
    public static  TextMeshPro  ScoreText;
    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60; //FPS
        score = 0;
        UpdateScoreText();
        
    }
    public static void UpdateScoreText()
    {
        ScoreText.text = "Score: " + score;
    }


   

}
