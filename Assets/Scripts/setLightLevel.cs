using UnityEngine;

public class setLightLevel : MonoBehaviour
{
    public PlayerController pc;
    public GameObject lowLight;
    public GameObject mediumLight;
    public GameObject highLight;

    // Update is called once per frame
    void Update()
    {
        float level = pc.battery.powers[1].getMagnitude();
        if (level == 1f){
            lowLight.SetActive(true);
            mediumLight.SetActive(false);
            highLight.SetActive(false);
        }else if (level == 2f){
            lowLight.SetActive(false);
            mediumLight.SetActive(true);
            highLight.SetActive(false);
        }else if (level == 3f){
            lowLight.SetActive(false);
            mediumLight.SetActive(false);
            highLight.SetActive(true);
        }else{
            lowLight.SetActive(false);
            mediumLight.SetActive(false);
            highLight.SetActive(false);
        }
    }
}
