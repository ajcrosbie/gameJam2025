using UnityEngine;

public class ButtonDoor : MonoBehaviour
{
    private bool moved = false;

    private bool isPressed = false;

    public GameObject door;
    private SpriteRenderer sr;
    public Sprite pressedSprite;

    void Start()
    {
        sr = gameObject.GetComponent<SpriteRenderer>();
    }

    void Update(){
        if (isPressed && !moved){
            transform.position = transform.position;
            door.transform.position = new Vector3(door.transform.position.x, door.transform.position.y + 0.1f, door.transform.position.z);
        }
    }

    void OnCollisionEnter2D(Collision2D triggerObject){
        isPressed = true;
        sr.sprite = pressedSprite;
    }
    
}

