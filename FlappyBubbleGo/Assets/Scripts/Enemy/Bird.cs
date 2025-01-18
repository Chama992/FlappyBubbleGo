using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bird : MonoBehaviour
{
    //public static event Action OnPlayerDeath;

    private Rigidbody2D rb;
    private Animator anim;
   
    private float Speed = -1f;
    [SerializeField] private AudioSource deathSoundEffect;

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

    }

    private void Update()
    {
        if (Time.time >= 20)
        {
            Speed = -1f - Time.time/40;
        }
        rb.velocity = new Vector2(Speed, 0);
    }
    
    public void Die()
    {
        anim.SetBool("Dead",true);
    }
}
