using System;
using System.Collections;
using UnityEngine;


    
public class BirdAnimationTrigger:MonoBehaviour
{
    private Animator Anim;
    private void Start()
    {
        Anim = GetComponent<Animator>();
    }
    public void Dead()
    {
        Anim.SetBool("Dead",false);
        Destroy(gameObject);
    }
}
