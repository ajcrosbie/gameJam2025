using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEditor;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{

    public int power = 10;              // Power slots for Battery
    public float moveSpeed = 5f;       // Movement speed
    public float jumpForce = 7f;       // Jump force
    public Light2D globalLight;        // Global light reference
    public Rigidbody2D rb;             // Rigidbody2D component

    public SpriteRenderer spriteRender; // Reference to sprite renderer

    public Sprite deathSprite;  //Sprite to swap to when dead
    
    public GameObject playerLight; //Reference to light on player
    public Battery battery;            // Reference to the Battery component
    public bool LeftRightUnlocked = true;
    public bool JumpUnlocked = true;


    public AudioSource sound; // Reference to audio source
    public AudioClip deathSound; // Death sound effect
    public AudioClip jumpSound; // Jump sound effect


    public GameObject deathParticles;  // Death particle effect

    private int timeToRespawn = 0;     // Time before respawn
    [SerializeField] private Vector2 groundCheckOffset;    // Ground check offset
    [SerializeField] private Vector2 groundCheckSize;      // Ground check size
    private LayerMask groundMask;      // Ground mask for collision checks

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Add the Battery component to the Player and initialize it
        battery = gameObject.AddComponent<Battery>();
        battery.InitializeBattery(power, new bool[] { true }); // Initialize battery with the powers

        groundMask = LayerMask.GetMask("Ground") + LayerMask.GetMask("Default");
    }

    void Update()
    {
        // Handle horizontal movement
        if (LeftRightUnlocked && timeToRespawn == 0)
        {
            float moveInput = Input.GetAxis("Horizontal");
            if (moveInput != 0)
            {
                rb.linearVelocity = new Vector2(moveInput * moveSpeed, rb.linearVelocity.y); // Correcting to `velocity`
            }
        }

        // Handle jumping
        if (timeToRespawn == 0 && JumpUnlocked && Input.GetButtonDown("Jump") && Physics2D.OverlapBox(rb.position + groundCheckOffset, groundCheckSize, 0f, groundMask))
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce); // Corrected to `velocity`
            sound.PlayOneShot(jumpSound);
        }


        for (int i = 0; i < 9; i++)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1 + i ))  // KeyCode.Alpha1 corresponds to "1", Alpha2 to "2", etc.
            {
                Debug.Log(i);
                battery.addPower(i);  // Calls battery boost on the corresponding power slot
            }
        }
    }

    void FixedUpdate(){
        // Respawn logic if the time to respawn has reached 1
        if (timeToRespawn == 1)
        {
            Scene scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(scene.name);        }

        if (timeToRespawn > 0)
        {
            timeToRespawn--;
        }
    }

    // Handle collisions with spikes
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Spike"))
        {
            Die();
        }
    }

    // Handle player death
    void Die()
    {
        if (timeToRespawn == 0)  // Only spawn particles if not already respawning
        {
            GameObject particles = Instantiate(deathParticles, transform.position, Quaternion.identity);
            // Set respawn time
            timeToRespawn = 60;
        }
         
        sound.PlayOneShot(deathSound);
        spriteRender.sprite = deathSprite;
        Destroy(playerLight);
    }

    // Visualize the ground check area in the editor
    void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireCube(rb.position + groundCheckOffset, groundCheckSize);
    }
}
