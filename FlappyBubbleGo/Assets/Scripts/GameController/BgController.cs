using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgController : MonoBehaviour
{
    // Start is called before the first frame update

    Vector3 startPos;

    public float speed = -0.005f;
    public float maxSpeed = -0.1f;
    public float weiyi = 0f;
    public bool moveFlag = false;
    public bool isTest = false;
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
            if (GameController.Instance.gameTime >= 20)
            {
                speed = -0.005f - (GameController.Instance.gameTime -20 ) * 0.0003f;
            }
            speed = Mathf.Max(speed, maxSpeed);
            transform.Translate(speed,0,0);
            if (!isTest)
            {
                GameController.Instance.floatDistance +=-speed * Time.deltaTime * 1000f /5;
            }
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
