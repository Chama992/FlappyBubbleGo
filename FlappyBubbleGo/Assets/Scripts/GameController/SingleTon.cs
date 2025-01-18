using System;
using UnityEngine;


public class SingleTon<T> : MonoBehaviour where T : SingleTon<T>
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
