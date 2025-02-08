using UnityEngine;
using UnityEngine.Rendering.Universal;

public class PlayerController : MonoBehaviour
{

    public int Power = 1;
    public float moveSpeed = 5f;
    public float jumpForce = 7f;
    public Light2D globalLight;
    public Rigidbody2D rb;

    public bool LeftRightUnlocked = true;
    public bool JumpUnlocked = true;

    [SerializeField] private Vector2 groundCheckOffset;
    [SerializeField] private Vector2 groundCheckSize;
    private LayerMask groundMask;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        groundMask = LayerMask.GetMask("Ground") + LayerMask.GetMask("Default");
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

        if (JumpUnlocked && Input.GetButtonDown("Jump") && Physics2D.OverlapBox(rb.position + groundCheckOffset, groundCheckSize, 0f, groundMask))
        {

            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
            // rb.rotation = rb.rotation + 90;

        }
        
        // TESTING GLOBAL LIGHTING -- AARAV
        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            globalLight.intensity = 1 - globalLight.intensity;
        }
    }
}
