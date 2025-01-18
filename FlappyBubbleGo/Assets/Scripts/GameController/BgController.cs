using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgController : MonoBehaviour
{
    // Start is called before the first frame update

    Vector3 startPos;

    public float speed = -0.01f;

    public float weiyi = 0f;
    
    void Start()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < -18.7f+weiyi)
        { 
            transform.position = startPos;
        }
        transform.Translate(speed,0,0);
    }
}
