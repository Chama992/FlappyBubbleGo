using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class BeginAnimController : SingleTon<BeginAnimController>
{
     public GirlTest GirlTest;
    public PlayableDirector timeline;
    public GameObject moveGos;
    public GameObject girlBubble;
    public GameObject girl;
    public GameObject BG;
    public AudioSource audio;
    public GameObject panel;
    public TMP_Text tiptext;
    public TMP_Text continuetext;
    public GameObject birdPrefab;//��������һ��prefab
    private GameObject bird;
    public TMP_Text congratext;
    public TMP_Text tip1text;
    private bool firstOff;
    private bool secondOff;
    private bool thirdOff;

    public int gameTime;
    // Start is called before the first frame update
    void Start()
    {
        timeline = GetComponent<PlayableDirector>();
        GirlTest = girlBubble.gameObject.GetComponent<GirlTest>();
        GirlTest.First += First;
        StartCoroutine(AddTestTime());
    }

    private IEnumerator AddTestTime()
    {
        while (true)
        {
            gameTime += 1;
            yield return null;
        }
    }

    private void First()
    {
        panel.SetActive(true);
        tiptext.text = "当心!屏幕上下边缘有不稳定气流，碰触边缘会导致少女的气泡爆炸!点击鼠标左键为气泡卸去浮力，气泡会自己降下来";
        continuetext.text = "按下任意键继续";
        BG.GetComponent<TestBgController>().StopMove();
        Time.timeScale = 0;
        Vector3 outScreenPos = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height,0f));
        float y = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height / 2, Camera.main.transform.position.z)).y;
        Vector3 pos = new Vector3(outScreenPos.x * 1.1f, y, 0);
        bird = Instantiate(birdPrefab,pos,Quaternion.identity);
        bird.GetComponent<Bird>().isTest = true;
        StartCoroutine(WaitToClickSecond());
    }

    private void ThirdTime()
    {
        panel.SetActive(true);
        tiptext.text = "当心!海鸥锋利的喙可以轻松测穿少女的泡泡，点击左键使用泡泡枪拖住它们!必要时也可以躲避它们。";
        continuetext.text = "按下任意键继续";
        Time.timeScale = 0;
        thirdOff = true;
        StartCoroutine(WaitToClickThird());
    }

    public IEnumerator WaitToClickThird()
    {
        while (true)
        {
            if (Input.GetMouseButtonDown(0))
            { 
                panel.SetActive(false);
                BG.GetComponent<TestBgController>().BeginMove();
                Time.timeScale = 1;
                secondOff = true;
                GirlTest.canShoot = true;
                GirlTest.Shoot();
                break;
            }
            yield return null;
        }
        yield return new WaitForSeconds(2f);
        tip1text.gameObject.SetActive(true);
        congratext.gameObject.SetActive(true);
        Time.timeScale = 0;
        StartCoroutine(WaitToClickBegin());
    }
    public IEnumerator WaitToClickBegin()
    {
        while (true)
        {
            if (Input.anyKeyDown)
            { 
                Time.timeScale = 1;
                SceneManager.LoadScene("LyhScene");
                break;
            }
            yield return null;
        }
    }
    public IEnumerator WaitToClickSecond()
    {
        while (true)
        {
            if (Input.anyKeyDown && firstOff)
            { 
                panel.SetActive(false);
                BG.GetComponent<TestBgController>().BeginMove();
                Time.timeScale = 1;
                GirlTest.bubbleCurWeight -= 90;
                secondOff = true;
                break;
            }
            yield return null;
        }
        yield return new WaitForSeconds(2f);
        ThirdTime();
    }
    public IEnumerator WaitToClickFirst()
    {
        while (true)
        {
            if (Input.anyKeyDown)
            { 
                panel.SetActive(false);
                BG.GetComponent<TestBgController>().BeginMove();
                Time.timeScale = 1;
                firstOff = true;
                break;
            }
            yield return null;
        }
    }
    
    public void StartTimeline()
    {
        timeline.Play();
        audio.Stop();
        MySoundManager.PlayAudio(Globals.SeaGullScream);
        moveGos.SetActive(true);
        girl.GetComponent<Animator>().SetBool("Wake",true);
        Invoke("FinishTimeline", (float)timeline.duration);
    }

    public void GirlBlow()
    {
        girl.transform.localPosition += Vector3.up * 0.5f;
        girlBubble.transform.localScale = girl.transform.localScale * 0.5f;
        girl.GetComponent<Animator>().SetBool("Blow",true);
    }
    public void FinishTimeline()
    {
        audio.clip = Resources.Load<AudioClip>("Audio/Game_BGM");
        audio.Play();
        girlBubble.GetComponent<GirlTest>().enabled = true;
        
        BG.GetComponent<TestBgController>().BeginMove();
        panel.SetActive(true);
        tiptext.text = "此时少女过度紧张，她会一直向气泡中吹气，什么都不操作时，气泡会越吹越大，增加浮力";
        continuetext.text = "按下任意键继续";
        BG.GetComponent<TestBgController>().StopMove();
        Time.timeScale = 0;
        StartCoroutine(WaitToClickFirst());
    }

}
