using System;
using UnityEngine;


public class GameController : MonoBehaviour
{
    private Player Player;
    public GameObject GameOverPanel;
    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        Player.PlayerDied += GameOver;
    }
    public void GameOver()
    {
        Debug.Log("Game Over");
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
}
