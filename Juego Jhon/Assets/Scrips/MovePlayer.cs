using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverPlayer : MonoBehaviour
{
    float horizontal;
    private Rigidbody2D rigiBodyPlaayer;
    public float jumpForce = 5f;
    private bool isGrounded;
    public Transform groundCheck;
    public float checkRadius = 0.5f;
    public LayerMask whatIsGround; 

    void Start()
    {
        rigiBodyPlaayer = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);
        

        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            
            rigiBodyPlaayer.velocity = new Vector2(rigiBodyPlaayer.velocity.x, jumpForce);
        }
    }

    private void FixedUpdate()
    {
        rigiBodyPlaayer.velocity = new Vector2(horizontal, rigiBodyPlaayer.velocity.y);
    }
}
