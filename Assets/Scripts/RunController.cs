using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunController : MonoBehaviour
{
    public Rigidbody2D playerRigidBody;
    public float gooseRunSpeed = 20f;
    public float jumpForce = 10f;  // Adjust this value for the desired jump height
    private bool m_Grounded = true;
    [SerializeField] private LayerMask m_WhatIsGround;
    [SerializeField] private Transform m_GroundCheck;
    const float k_GroundedRadius = .2f;

    Vector3 temporaryVectorReplaceMe;


    private void FixedUpdate()
    {
        // Set a constant forward velocity for the character
        playerRigidBody.velocity = new Vector2(gooseRunSpeed, playerRigidBody.velocity.y);

        // Check for jump input
        if (Input.touchCount > 0 && m_Grounded)
        {
            m_Grounded = false;
            // Set the y-component of the velocity to achieve jumping
            playerRigidBody.velocity = new Vector2(playerRigidBody.velocity.x, jumpForce);
        }

        // Check if the player is grounded
        Collider2D[] colliders = Physics2D.OverlapCircleAll(m_GroundCheck.position, k_GroundedRadius, m_WhatIsGround);
        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].gameObject != gameObject)
            {
                m_Grounded = true;
            }
        }
    }
    public Vector3 getPosition()
    {
        return transform.position;
        //Debug.Log("Getting player position, complete this method");
        //temporaryVectorReplaceMe = new Vector3(0.0f, 1.0f, 0.0f);
        //return temporaryVectorReplaceMe;
    }
}
