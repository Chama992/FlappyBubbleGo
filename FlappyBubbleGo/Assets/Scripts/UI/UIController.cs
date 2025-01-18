using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public Button startButton;
    public Button exitButton;
    public GameObject panel1;
    public GameObject panel2;
    // Start is called before the first frame update
    void Start()
    {
        startButton.onClick.AddListener(StartGame);
        exitButton.onClick.AddListener(ExitGame);
    }
    private void StartGame()
    {
        // panel1.SetActive(false);  
        // panel2.SetActive(true);
        SceneManager.LoadScene("LyhScene");
    }

    private void ExitGame()
    {
        #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
        #else
                Application.Quit();
        #endif
    }
}
