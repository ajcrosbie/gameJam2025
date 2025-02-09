using UnityEngine;

public class verticalMovement : Power
{
    // Initialize method to set up the power (since constructors don't work with MonoBehaviour)
    public void Initialize(int max, bool useable)
    {
        base.Initialize(max, useable);  // Call the base Power class initializer
    }

    public override float getMagnitude()
    {
        if (energyStored == 1){
            return 10f;
        } else if (energyStored == 2){
            return 15f;
        } else if (energyStored == 3){
            return 20f;
        } else{
            return 0f;

        }
    }
}
