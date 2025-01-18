using System;
using UnityEngine;


    
public class AnimationTrigger:MonoBehaviour
{
    private Animator GirlAnim;
    private Player player;
    private void Start()
    {
        GirlAnim = GetComponent<Animator>();
        player = GetComponentInParent< Player >();
    }

    public void ShootOver()
    {
        MySoundManager.PlayOneAudio(Globals.Shoot);
        GirlAnim.SetBool("Shoot",false);
        player.CreateBullet();
    }
    public void Blow()
    {
        MySoundManager.PlayOneAudio(Globals.GirlBlowBubble);
    }
}
