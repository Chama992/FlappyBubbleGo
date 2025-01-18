using System;
using UnityEngine;


    
public class AnimationTrigger:MonoBehaviour
{
    private Animator Anim;
    private Player player;
    private void Start()
    {
        Anim = GetComponentInParent<Animator>();
        player = GetComponentInParent< Player >();
    }

    public void ShootOver()
    {
        Anim.SetBool("Shoot",false);
        player.CreateBullet();
    }
}
