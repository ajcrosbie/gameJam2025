using UnityEngine;

public class setLightLevel : MonoBehaviour
{
    public PlayerController pc;
    public GameObject lowLight;
    public GameObject mediumLight;
    public GameObject highLight;

    public GameObject deathLight;

    private bool dead = false;

    // Update is called once per frame
    void FixedUpdate()
    {
        float level = pc.battery.powers[1].getMagnitude();
        if (dead || pc.GetTimeToRespawn() > 0){
            dead = true;
            lowLight.SetActive(false);
            mediumLight.SetActive(false);
            highLight.SetActive(false);
            deathLight.SetActive(true);
        }
        else if (level == 1f && !dead){
            lowLight.SetActive(true);
            mediumLight.SetActive(false);
            highLight.SetActive(false);
            deathLight.SetActive(false);
        }else if (level == 2f && !dead){
            lowLight.SetActive(false);
            mediumLight.SetActive(true);
            highLight.SetActive(false);
            deathLight.SetActive(false);

        }else if (level == 3f && !dead){
            lowLight.SetActive(false);
            mediumLight.SetActive(false);
            highLight.SetActive(true);
            deathLight.SetActive(false);

        }else if (!dead){
            lowLight.SetActive(false);
            mediumLight.SetActive(false);
            highLight.SetActive(false);
            deathLight.SetActive(false);

        }
    }
}
