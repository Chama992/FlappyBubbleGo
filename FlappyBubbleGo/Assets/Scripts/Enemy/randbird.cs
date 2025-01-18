using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class randbird : MonoBehaviour
{

    public GameObject prefab;//��������һ��prefab

    
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
        time = 10f;//ʱ��������
    }
    void CreatPrefab()
    {
        float y = Random.Range(-4f, 4f);
        prefab.transform.position = new Vector3(15f, y, 0);
        Instantiate(prefab);//ʵ����һ��prefab
        time = 10f;//ʹtime������λ
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



