using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GirlTest : MonoBehaviour
{   
    private Transform girl;
    public GameObject bulletPrefab;
    [Header("Parameter")] 
    public float bulletOffset;
    public float bulletSpeed;
    public Animator GirlAnim { get; private set; }
    public Rigidbody2D Rb{ get; private set; }
    [Header("Parameter")] 
    private Transform bubble;
    public float bubbleWeight;
    public float bubbleCurWeight;
    private Vector3 bulletDir;
    // public float lineLength;
    public float weightSpeed;
    public float basicSpeed;
    public bool firstFlag;
    public Action First;

    public bool canShoot;
    // Start is called before the first frame update
    void Start()
    {
        GirlAnim  = GetComponentInChildren<Animator>();
        Rb = GetComponent<Rigidbody2D>();
        bubble = transform.Find("Bubble");
        girl = transform.Find("Girl");
        bubbleCurWeight = bubbleWeight;
    }

    // Update is called once per frame
    void Update()
    {
        MySoundManager.PlayOneAudio(Globals.SeaGullScream);
        PlayerFlow();
    }
    private void PlayerFlow()
    {
        bubbleCurWeight += weightSpeed * Time.deltaTime;
        float ratio = bubbleCurWeight / bubbleWeight;
        bubble.localScale = new Vector3(ratio,ratio,ratio);
        Rb.velocity = Vector3.up * (bubbleCurWeight - bubbleWeight) * basicSpeed;
        Vector3 upPos = Camera.main.WorldToScreenPoint(transform.position);
        if (upPos.y > Screen.height && !firstFlag)
        {
            First?.Invoke();
            firstFlag = true;
        }
    }
    public void Shoot()
    {
        if (!canShoot)
        {
            return;
        }
        Vector3 mousePositon = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10));
        Vector3 targetPositon = girl.position + (mousePositon - girl.position).normalized;
        if (Input.GetMouseButtonDown(0))
        {
            GirlAnim.SetBool("Shoot",true);
            bulletDir = (targetPositon - girl.position).normalized;
        }
    }
    public void CreateBullet()
    {
        Bullet bullet = Instantiate(bulletPrefab, girl.position + bulletDir * bulletOffset, Quaternion.identity).GetComponent<Bullet>();
        bullet.Initialize(bulletSpeed, bulletDir);
        bullet.isTesting = true;
        bubbleCurWeight -= 30;
    }
}
