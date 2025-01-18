using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InGameUIController : SingleTon<InGameUIController>
{
    public TMP_Text scoreText;
    public TMP_Text killsText;
    public TMP_Text alertText;
    public Button backButton;

    private void Start()
    {
        backButton.onClick.AddListener(delegate { UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu"); });
        backButton.enabled = false;
    }

    public void SetDistance(int score)
    {
        scoreText.text ="Distance:" +  score.ToString();
    }

    public void SetAlert(string alert)
    {
        alertText.text =alert;
    }
    public void SetKills(int killCount)
    {
        killsText.text = "×" + killCount;
    }
}