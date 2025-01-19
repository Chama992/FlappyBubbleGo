using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Serialization;


public class GameController : SingleTon<GameController>
{
    private Player Player;
    private BgController bgController;
    private Randbird randbird;
    public GameObject GameOverPanel;
    public Texture2D mouseTexture;
    public int kills;
    private bool isGameOver;
    public AudioSource bgm;
    public AudioSource obgm;
    public int distance;
    public float floatDistance;
    public int gameTime;
    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        Player.enabled = false;
        bgController = GameObject.FindFirstObjectByType<BgController>().gameObject.GetComponent<BgController>();
        randbird = GameObject.FindFirstObjectByType<Randbird>().gameObject.GetComponent<Randbird>();
        Player.PlayerDied += GameOver;
        Cursor.SetCursor(mouseTexture, Vector2.zero, CursorMode.Auto);
        bgm.Stop();
        this.StartCoroutine(this.GameBeginTimer());
        bgController.StopMove();
        randbird.StopGenerate();
        InGameUIController.Instance.SetKills(kills);
        InGameUIController.Instance.SetDistance(kills);
    }
    public IEnumerator GameBeginTimer()
    {
        MySoundManager.PlayAudio(Globals.Go);
        Time.timeScale = 0;
        InGameUIController.Instance.SetAlert("3");
        yield return new WaitForSecondsRealtime(1f);
        InGameUIController.Instance.SetAlert("2");
        yield return new WaitForSecondsRealtime(1f);
        InGameUIController.Instance.SetAlert("1");
        yield return new WaitForSecondsRealtime(1f);
        InGameUIController.Instance.SetAlert("Start!");
        Time.timeScale = 1;
        yield return new WaitForSecondsRealtime(0.25f);
        bgm.Play();
        bgController.BeginMove();
        randbird.BeginGenerate();
        InGameUIController.Instance.SetAlert("");
        Player.enabled = true;
        InGameUIController.Instance.backButton.enabled = true;
        this.StartCoroutine(this.ScoreAddWithTime());
    }
    public IEnumerator ScoreAddWithTime()
    {
        while(!isGameOver)
        {
            SetDistance();
            gameTime += 1;
            yield return new WaitForSeconds(1f);
        }
    }

    public void GameOver()
    {
        if (isGameOver)
            return;
        isGameOver = true;
        MySoundManager.PlayAudio(Globals.GameOver);
        Animator BubbleAnim = Player.transform.Find("Bubble").GetComponent<Animator>();
        BubbleAnim.SetBool("Dead",true);
        StartCoroutine(GameEnd());
    }

    public IEnumerator GameEnd()
    {
        yield return new WaitForSecondsRealtime(1f);
        //停止刷新小鸟
        randbird.StopGenerate();
        //停止背景移动
        bgController.StopMove();
        //打开结束UI界面
        InGameUIController.Instance.gameObject.SetActive(false);
        GameOverPanel.GetComponent<GameOverUIController>().GetGameValue();
        GameOverPanel.SetActive(true);
    }

    private void OnDisable()
    {
        Player.PlayerDied -= GameOver;
    }

    public void SetDistance()
    {
        distance = (int)floatDistance;
        InGameUIController.Instance.SetDistance(distance);
    }
    public void AddKills(int killCount)
    {
        kills += killCount;
        InGameUIController.Instance.SetKills(kills);
    }
}
