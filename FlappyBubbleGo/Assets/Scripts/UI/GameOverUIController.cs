using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverUIController : MonoBehaviour
{
    public Button restartButton;
    public Button quitButton;
    public Button rebornButton;
    // Start is called before the first frame update
    void Start()
    {
        rebornButton.onClick.AddListener(RestartGame);
        quitButton.onClick.AddListener(QuitGame);
        restartButton.onClick.AddListener(Reborn);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GetGameValue()
    {
        
    }

    public void RestartGame()
    {
        
    }
    public void QuitGame()
    {
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
