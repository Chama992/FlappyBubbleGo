using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestBgController : MonoBehaviour
{
    // Start is called before the first frame update

    Vector3 startPos;

    public float speed = -0.005f;
    public float maxSpeed = -0.1f;
    public float weiyi = 0f;
    public bool moveFlag = false;
    void Start()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (moveFlag)
        {
            if (transform.position.x < -51.32f+weiyi)
            { 
                transform.position = startPos;
            }
            transform.Translate(speed,0,0);
        }
    }

    public void StopMove()
    {
        moveFlag = false;
    }
    public void BeginMove()
    {
        moveFlag = true;

    }
}
