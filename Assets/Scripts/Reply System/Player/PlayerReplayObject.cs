using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerReplayObject : ReplayObject
{
    private Animator animator;
    private SpriteRenderer sr;

    private void Awake()
    {
        animator = GetComponentInChildren<Animator>();
        sr = GetComponentInChildren<SpriteRenderer>();
    }

    public override void SetDataForFrame(ReplayData data)
    {
        // Typecast data
        PlayerReplayData playerData = (PlayerReplayData) data;
        
        // Position
        this.transform.position = playerData.position;
        
        // Animator
        animator.SetBool("isRunning", playerData.isRunning);
        animator.SetBool("isGrounded", playerData.isGrounded);
        animator.SetBool("isFalling", playerData.isFalling);
        
        // Sprite Direction
        sr.flipX = !playerData.isFacingRight;
    }
    
}
