using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float moveSpeed;
    private Vector3 moveDirection;
    private float scale;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        rb.velocity = moveDirection.normalized * moveSpeed;
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
                bird.Die();
            }
        }
    }

    public void Initialize( float _moveSpeed,float _scale,Vector3 _moveDirection)
    {
        moveSpeed = _moveSpeed;
        scale = _scale;
        moveDirection = _moveDirection;
    }
}
