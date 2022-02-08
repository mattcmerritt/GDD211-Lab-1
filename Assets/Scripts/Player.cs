using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField]
    private bool IsGrounded;

    [SerializeField]
    private Rigidbody rb;

    [SerializeField]
    private float JumpForce;

    [SerializeField]
    private GameObject GroundCheck;

    [SerializeField]
    private Animator ani;

    private void Update()
    {
        // Checking if there is ground under the player to jump off of
        RaycastHit hit;
        if (Physics.Raycast(GroundCheck.transform.position, Vector3.down, out hit, 1f))
        {
            IsGrounded = hit.collider.tag == "Platform";
        }
        else
        {
            IsGrounded = false;
        }
        Debug.DrawRay(GroundCheck.transform.position, Vector3.down, Color.red);

        // Jumping
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded)
        {
            rb.AddForce(Vector3.up * JumpForce);
        }

        if (transform.position.y < -10)
        {
            // High score tracking
            int score = FindObjectOfType<UI>().GetScore();

            PlayerPrefs.SetInt("PrevScore", score);
            if (!PlayerPrefs.HasKey("HighScore"))
            {
                PlayerPrefs.SetInt("HighScore", score);
            }
            if (PlayerPrefs.HasKey("HighScore") && PlayerPrefs.GetInt("HighScore") <= score)
            {
                PlayerPrefs.SetInt("HighScore", score);
            }

            PlayerPrefs.Save();

            // Reload Level
            SceneManager.LoadScene("Game");
        }

        // Animation
        ani.SetFloat("Speed", LevelGeneration.GetCurrentSpeed());
        ani.SetBool("OnGround", IsGrounded);
    }
}
