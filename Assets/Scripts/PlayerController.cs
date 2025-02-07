using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public int Power = 1;
    public float moveSpeed = 5f;
    public float jumpForce = 7f;
    public Rigidbody2D rb;

    public bool LeftRightUnlocked = true;
    public bool JumpUnlocked = true;

    private bool isGrounded = true;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Handle horizontal movement
        if (LeftRightUnlocked)
        {
        float moveInput = Input.GetAxis("Horizontal");
        rb.linearVelocity = new Vector2(moveInput * moveSpeed, rb.linearVelocity.y);
        }

        if (JumpUnlocked && isGrounded && Input.GetButtonDown("Jump")){

            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);

        }
    }

        void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the player is on the ground
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        // Check if the player is no longer on the ground
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}
