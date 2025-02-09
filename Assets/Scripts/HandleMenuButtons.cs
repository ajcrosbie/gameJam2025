using UnityEngine;
using UnityEngine.SceneManagement;

public class HandleMenuButtons : MonoBehaviour
{

    public void QuitButton(){
        Application.Quit();
    }

    public void PlayButton(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
