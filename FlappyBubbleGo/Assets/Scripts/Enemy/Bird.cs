using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bird : MonoBehaviour
{
    //public static event Action OnPlayerDeath;

    private Rigidbody2D rb;
    private Animator anim;
    [SerializeField] private AudioSource deathSoundEffect;

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        rb.velocity = new Vector2(-1f, 0);
    }
    
    public void Die()
    {
        // anim.SetTrigger("death");
        Destroy(gameObject);
    }
}
