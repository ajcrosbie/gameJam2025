using UnityEngine;

public class HorizontalMovement : Power
{
    // Initialize method to set up the power (since constructors don't work with MonoBehaviour)
    public void Initialize(int max, bool useable)
    {
        base.Initialize(max, useable);  // Call the base Power class initializer
    }

    public override float getMagnitude()
    {
        return energyStored * 5f;
    }
}
