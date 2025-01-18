using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;

public class Player : MonoBehaviour
{
    #region Components
    public Animator Anim { get; private set; }
    public Rigidbody2D Rb{ get; private set; }
    private Transform bubble;
    private Transform girl;
    private LineRenderer line;
    private AnimationTrigger animTrigger;
    #endregion
    #region Prefabs
    public GameObject bulletPrefab;
    #endregion
    #region MoveParameter

    [Header("Parameter")] 
    public float bubbleWeight;
    public float bubbleCurWeight;
    public float bulletOffset;
    public float bulletSpeed;
    private Vector3 bulletDir;
    public float lineLength;
    public float weightSpeed;
    public float basicSpeed;
    #endregion
    
    // Start is called before the first frame update
    void Start()
    {
        line= GetComponentInChildren<LineRenderer>();
        line.positionCount = 2;
        line.endWidth = 0.1f;
        line.startWidth = 0.1f;
        Anim  = GetComponentInChildren<Animator>();
        Rb = GetComponent<Rigidbody2D>();
        bubble = transform.Find("Bubble");
        girl = transform.Find("Girl");
        bubbleCurWeight = bubbleWeight;
    }

    // Update is called once per frame
    void Update()
    {
        PlayerFlow();
        Shoot();
        DeadCheck();
    }

    private void DeadCheck()
    {
        Vector3 screenPos = Camera.main.WorldToScreenPoint(girl.position);
        if (screenPos.x < Screen.width || screenPos.x < 0 || screenPos.y > Screen.height || screenPos.y < 0)
        {
            
        }
    }

    private void Shoot()
    {   
        Vector3 mousePositon = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10));
        Vector3 targetPositon = girl.position + (mousePositon - girl.position).normalized * lineLength;
        line.SetPosition(0, girl.position);
        line.SetPosition(1, targetPositon);
        if (Input.GetMouseButtonDown(0))
        {
            Anim.SetBool("Shoot",true);
            bulletDir = (targetPositon - girl.position).normalized;
        }
    }
    public void CreateBullet()
    {
        Instantiate(bulletPrefab, girl.position + bulletDir * bulletOffset, Quaternion.identity).GetComponent<Bullet>().Initialize(bulletSpeed, 1, bulletDir);
        bubbleCurWeight -= 50;
    }
    private void PlayerFlow()
    {
        bubbleCurWeight += weightSpeed * Time.deltaTime;
        float ratio = bubbleCurWeight / bubbleWeight;
        bubble.localScale = new Vector3(ratio,ratio,ratio);
        Rb.velocity =Vector3.up * (bubbleCurWeight - bubbleWeight) * basicSpeed;
    }
}
