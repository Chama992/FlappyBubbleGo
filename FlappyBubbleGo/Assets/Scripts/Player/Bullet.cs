using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float moveSpeed;
    private Vector3 moveDirection;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = moveDirection.normalized * moveSpeed; 
    }

    private void Update()
    {
        Vector3 pos = Camera.main.WorldToScreenPoint(transform.position);
        if (pos.x > Screen.width || pos.x < 0 || pos.y > Screen.height || pos.y < 0)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            Bird bird = other.GetComponent<Bird>();
            if (bird)
            {
                MySoundManager.PlayAudio(Globals.BirdHit);
                Destroy(this.gameObject);
                bird.Die();
                GameController.Instance.AddKills(1);
            }
        }
    }

    public void Initialize( float _moveSpeed,Vector3 _moveDirection)
    {
        moveSpeed = _moveSpeed;
        moveDirection = _moveDirection;
    }
}
