using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private bool IsGrounded;

    [SerializeField]
    private Rigidbody rb;

    [SerializeField]
    private float JumpForce;

    private void Update()
    {
        // Checking if there is ground under the player to jump off of
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit, 1f))
        {
            IsGrounded = hit.collider.tag == "Platform";
        }
        else
        {
            IsGrounded = false;
        }
        //Debug.DrawRay(transform.position, Vector3.down, Color.red);

        // Jumping
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded)
        {
            rb.AddForce(Vector3.up * JumpForce);
        }

        if (transform.position.y < -10)
        {
            Debug.LogError("You Died");
        }
    }
}
