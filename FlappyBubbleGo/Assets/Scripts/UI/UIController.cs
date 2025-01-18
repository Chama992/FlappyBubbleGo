using System;
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
    private BeginAnimController beginAnimController;
    public Action GameBegin;
    public GameObject howl;
    public GameObject bg;
    // Start is called before the first frame update
    void Start()
    {
        beginAnimController = FindFirstObjectByType<BeginAnimController>().gameObject.GetComponent<BeginAnimController>();
        GameBegin += beginAnimController.StartTimeline;
        startButton.onClick.AddListener(StartGame);
        exitButton.onClick.AddListener(ExitGame);
    }

    private void OnDisable()
    {
        GameBegin -= beginAnimController.StartTimeline;
    }

    private void StartGame()
    {
        // panel1.SetActive(false);  
        // panel2.SetActive(true);
        MySoundManager.PlayAudio(Globals.PressButtonSound);
        panel1.SetActive(false);
        bg.SetActive(false);
        howl.SetActive(true);
        // SceneManager.LoadScene("LyhScene");
        StartCoroutine(GameBeginAnimation());
        GameBegin?.Invoke();
    }

    private IEnumerator GameBeginAnimation()
    {
        yield return new WaitForSeconds(1f);
        howl.SetActive(false);
    }

    private void ExitGame()
    {
        MySoundManager.PlayAudio(Globals.PressButtonSound);
        #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
        #else
                Application.Quit();
        #endif
    }
}
