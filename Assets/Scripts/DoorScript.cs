using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorScript : MonoBehaviour
{

        void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the player hits the door collider
        // Pretty sure this is not a good way to do it - Could be improved by having player press key to enter door etc.
        // Will try to come back later if time
        if (collision.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            Debug.Log("Overlap");
        }
    }
}
