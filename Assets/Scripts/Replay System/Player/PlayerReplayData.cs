using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerReplayData : ReplayData
{
    public bool isRunning { get; private set; }
    public bool isGrounded { get; private set; }
    public bool isFalling { get; private set; }
    public bool isFacingRight { get; private set; }

    
    // Data tracking
    public PlayerReplayData(Vector3 position, bool isFalling, bool isGrounded, bool isRunning, bool isFacingRight)
    {
        // Player Position
        this.position = position;
        
        // Player Animation States
        this.isFalling = isFalling;
        this.isGrounded = isGrounded;
        this.isRunning = isRunning;
        
        // Sprite Direction
        this.isFacingRight = isFacingRight;

    }
    
}
