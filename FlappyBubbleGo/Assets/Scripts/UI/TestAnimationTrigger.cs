using System;
using UnityEngine;


    
public class TestAnimationTrigger:MonoBehaviour
{
    private Animator GirlAnim;
    private GirlTest player;
    private void Start()
    {
        GirlAnim = GetComponent<Animator>();
        player = GetComponentInParent< GirlTest >();
    }

    public void ShootOver()
    {
        MySoundManager.PlayOneAudio(Globals.Shoot);
        GirlAnim.SetBool("Shoot",false);
        player.CreateBullet();
    }
}
