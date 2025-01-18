using System;
using TMPro;
using UnityEngine;

public class InGameUIController : Singleton<InGameUIController>
{
    public TMP_Text scoreText;

    public void SetScore(int score)
    {
        scoreText.text ="Score:" +  score.ToString();
    }
}