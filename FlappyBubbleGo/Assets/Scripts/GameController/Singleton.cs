using System;
using UnityEngine;


public class Singleton<T> : MonoBehaviour where T : Singleton<T>
{
    private static T _instance;
    public static T Instance
    {
        get
        {
            return _instance;
        }
    }

    private void Awake()
    {
        if (_instance != null)
        {
            if (_instance != this)
            { 
                Destroy(gameObject);   
            }
        }
        else
        {
            _instance = this as T;
        }
    }
}
