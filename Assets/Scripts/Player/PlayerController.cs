using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using Unity.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Stores core references
    private Rigidbody2D rbody;
    private Animator anim;
    private CapsuleCollider2D coll2D;

    // Stores movement speed
    [SerializeField] private float moveSpeed;
    [SerializeField] private float jumpForce;
    [SerializeField] private float fallThreshold = -0.1f;
    private float moveX;

    // Variables for checking player state
    private bool isFalling;
    private bool isJumping;
    private bool isFacingRight;

    // Jump Checking
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private float coyoteTime = 0.2f;
    private float coyoteTimeCounter;
    
    [SerializeField] private float jumpFalloff = 0.5f;
    [SerializeField] private float jumpBuffer = 0.2f;
    private float jumpBufferCounter;
    private float jumpCooldown = 0.4f;

    [SerializeField] private bool doubleJumped;

    // Recording Variables
    private Recorder recorder;

    // Called when player is activated
    private void Awake()
    {
        recorder = GetComponent<Recorder>();
        rbody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        coll2D = GetComponent<CapsuleCollider2D>();
    }

    // Start is called before the first frame update
    private void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        // Movement Input Check
        moveX = Input.GetAxis("Horizontal");

        IsGrounded();
        DirectionCheck();

        // Coyote time logic
        if (IsGrounded())
        {
            coyoteTimeCounter = coyoteTime;
        }
        else
        {
            coyoteTimeCounter -= Time.deltaTime;
        }

        // Jump buffer
        if (Input.GetButtonDown("Jump"))
        {
            jumpBufferCounter = jumpBuffer;
        }
        else
        {
            jumpBufferCounter -= Time.deltaTime;
        }
        
        // Jump
        if (jumpBufferCounter >= 0 && coyoteTimeCounter > 0 && !isJumping)
        {
            Jump();
            StartCoroutine(JumpCooldown());
            
        }
        
        // Double Jump
        if (jumpBufferCounter >= 0 && !doubleJumped && !IsGrounded())
        {
            Debug.Log("DoubleJump!");
            Jump();
        }
        
        // Double jump reset when on ground
        if (IsGrounded())
        {
            doubleJumped = false;
        }
        

        if (Input.GetButtonUp("Jump") && rbody.velocity.y > 0)
        {
            rbody.velocity = new Vector2(rbody.velocity.x, rbody.velocity.y * jumpFalloff);
        }

        FallCheck();

        // Set Animations
        anim.SetBool("isRunning", moveX != 0);
        anim.SetBool("isGrounded", IsGrounded());
        anim.SetBool("isFalling", isFalling);
    }

    private void FixedUpdate()
    {
        // Movement calculations
        rbody.velocity = new Vector2(moveX * moveSpeed, rbody.velocity.y);
    }

    private void LateUpdate()
    {
        // Record replay data for the frame
        ReplayData data = new PlayerReplayData(this.transform.position, isFalling, IsGrounded(), moveX != 0, isFacingRight);
        recorder.RecordReplayFrame(data);
    }

    private void Jump()
    {
        rbody.velocity = new Vector2(rbody.velocity.x, jumpForce);
        jumpBufferCounter = 0;
        if (!doubleJumped && !IsGrounded())
        {
            doubleJumped = true;
        }
    }

    private bool IsGrounded()
    {
        var bounds = coll2D.bounds;
        RaycastHit2D raycastHit = Physics2D.BoxCast(bounds.center, bounds.size, 0, Vector2.down, 0.1f, groundLayer);
        return raycastHit.collider != null;
    }

    private void DirectionCheck()
    {
        // Sprite direction
        if (moveX >= 0.1)
        {
            transform.localScale = Vector3.one;
            isFacingRight = true;
        }
        else if (moveX <= -0.1)
        {
            transform.localScale = new Vector3(-1, 1, 1);
            isFacingRight = false;
        }
    }

    private void FallCheck()
    {
        // Fall detection
        if (rbody.velocity.y < fallThreshold)
        {
            isFalling = true;
        }
        else
        {
            isFalling = false;
        }
    }

    private IEnumerator JumpCooldown()
    {
        isJumping = true;
        yield return new WaitForSeconds(jumpCooldown);
        isJumping = false;
    }
}