using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEditor;
using UnityEngine;
using Random = UnityEngine.Random;

public class Randbird : MonoBehaviour
{
    public bool canGenerate = false;
    public GameObject birdPrefab;//��������һ��prefab
    public float generateTime;
    public bool IsCanCreat
    {
        get
        {
            return time <= 0f;
        }
    }
    private float time;
    void Start()
    {
        time = math.max(generateTime, 2f);
    }
    void CreatPrefab()
    {
        Vector3 outScreenPos = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height,0f));
        float yMax = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z)).y;
        float yMin = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0f, Camera.main.transform.position.z)).y;
        float y = Random.Range(yMax, yMin);
        Vector3 pos = new Vector3(outScreenPos.x * 1.5f, y, 0);
        Instantiate(birdPrefab,pos,quaternion.identity);
        if(GameController.Instance.gameTime>= 20)
        {
            generateTime = 5 - (GameController.Instance.gameTime-20) * 0.055f;
        }
        time = math.max(generateTime, 1.5f); 
    }
    void Update()
    {
        if (canGenerate)
        {
            if (time > 0)
            {
                time -= Time.deltaTime;
            }
            if (IsCanCreat)
            {
                CreatPrefab();
            }
        }
    }
    public void StopGenerate()
    {
        canGenerate = false;
    }
    public void BeginGenerate()
    {
        canGenerate = true;
    }
}



