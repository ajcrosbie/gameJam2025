using UnityEngine;
using UnityEngine.SceneManagement;

public class HandleMenuButtons : MonoBehaviour
{
    void Start(){
        Screen.SetResolution(720, 360, false);
    }
    public void QuitButton(){
        Application.Quit();
    }

    public void PlayButton(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
