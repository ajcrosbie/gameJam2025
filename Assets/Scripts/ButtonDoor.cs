using UnityEngine;

public class ButtonDoor : MonoBehaviour
{
    public AudioSource sound;
    public AudioClip audioClip;

    private bool moved = false;

    private bool isPressed = false;

    public float doorSpeed = 0.02f;
    public bool horizontal = false;

    public GameObject door;
    private SpriteRenderer sr;
    public Sprite pressedSprite;

    void Start()
    {
        sr = gameObject.GetComponent<SpriteRenderer>();
    }

    void FixedUpdate(){
        if (isPressed && !moved){
            transform.position = transform.position;
            if (horizontal){
                door.transform.localPosition = new Vector3(door.transform.localPosition.x + doorSpeed, door.transform.localPosition.y, door.transform.localPosition.z);
            }else{
                door.transform.localPosition = new Vector3(door.transform.localPosition.x, door.transform.localPosition.y - doorSpeed, door.transform.localPosition.z);
            }
        }
    }

    void OnCollisionEnter2D(Collision2D triggerObject){
        isPressed = true;
        sr.sprite = pressedSprite;
        sound.PlayOneShot(audioClip);
    }
}
    


