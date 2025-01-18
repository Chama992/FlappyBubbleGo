using System;
using System.Collections;
using UnityEngine;


public class GameController : Singleton<GameController>
{
    private Player Player;
    public GameObject GameOverPanel;
    public Texture2D mouseTexture;
    public int score;
    private bool isGameOver;
    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        Player.PlayerDied += GameOver;
        Cursor.SetCursor(mouseTexture, Vector2.zero, CursorMode.Auto);
        this.StartCoroutine(this.ScoreAddWithTime());
    }

    public IEnumerator ScoreAddWithTime()
    {
        while(!isGameOver)
        {
            score++;
            SetScoreText();
            yield return new WaitForSeconds(1f);
        }
    }

    public void GameOver()
    {
        // Debug.Log("Game Over");
        
        Animator BubbleAnim = Player.transform.Find("Bubble").GetComponent<Animator>();
        BubbleAnim.SetBool("Dead",true);
        Player.gameObject.SetActive(false);
        //停止刷新小鸟
        //停止背景移动
        //打开结束UI界面
        GameOverPanel.GetComponent<GameOverUIController>().GetGameValue();
        GameOverPanel.SetActive(true);
    }
    private void OnDisable()
    {
        Player.PlayerDied -= GameOver;
    }

    public void AddScore(int scoreValue)
    {
        score += scoreValue;
        SetScoreText();
    }

    public void SetScoreText()
    {
        InGameUIController.Instance.SetScore(score);
    }
}
