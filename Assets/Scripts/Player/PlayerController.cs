using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Stores reference to RigidBody
    private Rigidbody2D rbody;

    // Stores movement speed
    [SerializeField] private float moveSpeed;
    [SerializeField] private float jumpForce;
    private float moveX = 0f;

    // Start is called before the first frame update
    void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
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
            rbody.velocity = new Vector2(rbody.velocity.x, jumpForce);
        }
    }

    private void FixedUpdate() {
        // Movement calculations
        rbody.velocity = new Vector2(moveX * moveSpeed, rbody.velocity.y);
    }
}
