using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverUIController : MonoBehaviour
{
    public Button restartButton;
    public Button quitButton;
    public TMP_Text scoreText;
    public TMP_Text bestScoreText;
    public TMP_Text killText;
    public TMP_Text bestKillText;
    public TMP_Text levelText;
    // Start is called before the first frame update
    void Start()
    {
        quitButton.onClick.AddListener(QuitGame);
        restartButton.onClick.AddListener(RestartGame);
    }
    public void GetGameValue()
    {
        int bestDistance = PlayerPrefs.GetInt("bestDistance", 0);
        int bestKils = PlayerPrefs.GetInt("bestKils", 0);
        int distance = GameController.Instance.distance;
        int kils = GameController.Instance.kills;
        if (bestDistance < distance )
        {
            bestScoreText.text = distance.ToString();
            PlayerPrefs.SetInt("bestDistance", distance);
        }
        else
        {
            bestScoreText.text = bestDistance.ToString();
        }
        if (bestKils < kils)
        {
            PlayerPrefs.SetInt("bestKils", kils);
            bestKillText.text = kils.ToString();
        }
        else
        {
            bestKillText.text = bestKils.ToString();
        }
        scoreText.text = GameController.Instance.distance.ToString();
        killText.text = GameController.Instance.kills.ToString();
        int score = distance + kils * 5;
        string level;
        if (score <100)
        {
            level = "D";
        }else if (score < 200)
        {
            level = "C";
        }else if (score < 300)
        {level  = "B";
        }else if (score < 400)

        {
            level = "A";
        }
        else if (score < 500)
        {
            level = "S";
        }else if (score < 700)
        {
            level = "SS";
        }else if (score < 1000)
        {
            level = "SSS";
        }
        else
        {
            level = "ACE";
        }

        levelText.text = level;
    }

    public void RestartGame()
    {
        MySoundManager.PlayAudio(Globals.PressButtonSound);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void QuitGame()
    {
        MySoundManager.PlayAudio(Globals.PressButtonSound);
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
    public void Reborn()
    {
    }
}
