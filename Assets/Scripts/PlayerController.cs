using UnityEngine;
// tiny change
using UnityEngine.Rendering.Universal;

public class PlayerController : MonoBehaviour{
    public GameObject respawnPoint;

    public int power = 1;
    public float moveSpeed = 5f;
    public float jumpForce = 7f;
    public Light2D globalLight;
    public Rigidbody2D rb;
    public Battery battery;
    public bool LeftRightUnlocked = true;
    public bool JumpUnlocked = true;

    public GameObject deathParticles;

    [SerializeField] private Vector2 groundCheckOffset;
    [SerializeField] private Vector2 groundCheckSize;
    private LayerMask groundMask;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        battery = new Battery(power);
    }
    void Update()
    {
        // Handle horizontal movement
        if (LeftRightUnlocked)
        {
        float moveInput = Input.GetAxis("Horizontal");
        if (moveInput != 0) {
            rb.linearVelocity = new Vector2(moveInput * moveSpeed, rb.linearVelocity.y);
        }
        }

        if (JumpUnlocked && Input.GetButtonDown("Jump") && Physics2D.OverlapBox(rb.position + groundCheckOffset, groundCheckSize, 0f, groundMask))
        {

            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
            // rb.rotation = rb.rotation + 90;

        }
    }

    void OnCollisionEnter2D(Collision2D collision){
        if (collision.gameObject.CompareTag("Spike")){
            Die();
        }
    }


    //Currently issues with spawning multiple particles when landing on multiple spikes - Im working on it
    void Die(){
        GameObject particles = Instantiate(deathParticles);
        particles.transform.position = transform.position;
        
        transform.position = respawnPoint.transform.position;
    }
}
