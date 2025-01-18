using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEditor;
using UnityEngine;
using Random = UnityEngine.Random;

public class Randbird : MonoBehaviour
{
    public GameObject birdPrefab;//��������һ��prefab
    public float generateTime;
    public bool IsCanCreat
    {
        get
        {
            return time <= 0f;
        }
    }//�����ж�time�����Ƿ��Ѿ�Ϊ0��������ʱ���Ƿ�ﵽ����
    private float time;//ʱ����
    void Start()
    {
        time = generateTime;//ʱ��������
    }
    void CreatPrefab()
    {
        Vector3 outScreenPos = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height,0f));
        float yMax = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z)).y;
        float yMin = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0f, Camera.main.transform.position.z)).y;
        float y = Random.Range(yMax, yMin);
        Vector3 pos = new Vector3(outScreenPos.x * 1.5f, y, 0);
        Instantiate(birdPrefab,pos,quaternion.identity);//ʵ����һ��prefab
        time = generateTime;//ʹtime������λ
    }
    void Update()
    {
        if (time > 0)
        {
            time -= Time.deltaTime;//��ȥÿһ֡�����ĵ�ʱ��
        }
        if (IsCanCreat)
        {
            CreatPrefab();
        }
    }
}



