using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    public TextMeshProUGUI scoreText;

    public static int score=0;

    private int addValue = 1;

    private void Awake()
    {
        instance = this;
    
    }

    private void Start()
    {
        scoreText.text = "Points  " + score.ToString();
    }
    public void AddPoint()
    {
        score += addValue;
        scoreText.text = "Points  " + score.ToString();
    }
    private void Update()
    {
        
    }
}
