using System;
using UnityEngine;


    
public class BAnimationTrigger:MonoBehaviour
{
    private Animator BubbleAnim;
    private Player player;
    private void Start()
    {
        BubbleAnim = GetComponent<Animator>();
        player = GetComponentInParent< Player >();
    }
    public void PlayerDead()
    {
        BubbleAnim.SetBool("Dead",false);
        MySoundManager.PlayAudio(Globals.BubbleBlow);
        MySoundManager.PlayAudio(Globals.GirlDie);
        player.gameObject.SetActive(false);
    }
}
