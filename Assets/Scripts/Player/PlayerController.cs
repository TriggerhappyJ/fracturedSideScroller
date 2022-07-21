using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Stores reference to RigidBody
    private Rigidbody2D rbody;
    private Animator anim;

    // Stores movement speed
    [SerializeField] private float moveSpeed;
    [SerializeField] private float jumpForce = 0f;
    [SerializeField] private float fallThreshold = -0.1f;
    private float moveX = 0f;

    // Variables for checking player state
    private bool isGrounded;
    private bool isFalling;

    // Start is called before the first frame update
    void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // Movement Input Check
        moveX = Input.GetAxis("Horizontal");

        // Sprite direction
        if (moveX >= 0.1)
        {
            transform.localScale = Vector3.one;
        }
        else if (moveX <= -0.1)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }

        // Jump
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
 
        if (rbody.velocity.y < fallThreshold)
        {
            isFalling = true;
        }
        else
        {
            isFalling = false;
        }

        // Set Animations
        anim.SetBool("isRunning", moveX != 0);
        anim.SetBool("isGrounded", isGrounded);
        anim.SetBool("isFalling", isFalling);
    }

    private void FixedUpdate() 
    {
        // Movement calculations
        rbody.velocity = new Vector2(moveX * moveSpeed, rbody.velocity.y);
    }

    private void Jump()
    {
        rbody.velocity = new Vector2(rbody.velocity.x, jumpForce);
        isGrounded = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = true;
        }
    }
}
