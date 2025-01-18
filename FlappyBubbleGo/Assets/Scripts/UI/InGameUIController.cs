using System;
using TMPro;
using UnityEngine;

public class InGameUIController : SingleTon<InGameUIController>
{
    public TMP_Text scoreText;
    public TMP_Text alertText;
    public void SetScore(int score)
    {
        scoreText.text ="Score:" +  score.ToString();
    }

    public void SetAlert(string alert)
    {
        alertText.text =alert;
    }
}