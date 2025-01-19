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
   private bool dead = false;
    private float Speed = -1f;
    private float maxSpeed = -2f;
    [SerializeField] private AudioSource deathSoundEffect;
    public bool isTest = false;
    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

    }

    private void Update()
    {
        int time;
        if (isTest)
        {
            time = BeginAnimController.Instance.gameTime;
        }
        else
        {
            time = GameController.Instance.gameTime;
        }
        if (dead)
        {
            return;
        }
        if (time >= 20)
        {
            Speed = -1f - (time -  20) * 0.025f;
        }
        Speed = Mathf.Max(Speed, maxSpeed);
        rb.velocity = new Vector2(Speed, 0);
    }
    
    public void Die()
    {
        dead = true;
        anim.SetBool("Dead",true);
        this.enabled = false;
    }
}
