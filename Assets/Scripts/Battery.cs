using UnityEngine;

public class Battery : MonoBehaviour
{
    public int maxBatteries;  // Number of power slots
    public Power[] powers;    // Array to store the powers

    // ✅ Constructor no longer required - initialization will happen in Start()
    
    // Initialize the battery with a given number of power slots and their on/off states
    public void InitializeBattery(int powerSlots, bool[] isOnList)
    {
        maxBatteries = powerSlots;
        powers = new Power[maxBatteries];  // Initialize the array to hold the Power objects
        
        // Initialize each Power based on the isOnList
        for (int i = 0; i < maxBatteries; i++)
        {
            if (i < isOnList.Length)
            {
                bool isOn = isOnList[i];  // Set the "on" state from the list
                powers[i] = new HorizontalMovement(5, isOn);  // Example Power subclass
            }
            else
            {
                // Default case: Create power with default settings
                powers[i] = new HorizontalMovement(5, true);  // Default is "on"
            }
        }
    }

    private void OnGUI()
    {
        draw();
    }

    private void draw()
    {
        if (powers == null) return;

        for (int i = 0; i < powers.Length; i++)
        {
            if (powers[i] != null)
            {
                powers[i].drawBars(i);  // Draw each power's bars with an offset
            }
        }
    }

    private void indicateInvalidOperation()
    {
        Debug.LogError("Invalid Operation!");
    }

    public int addPower(int i)
    {
        if (i >= powers.Length || powers[i] == null)
        {
            indicateInvalidOperation();
            return 0;
        }

        if (powers[i].addPower())
        {
            return (int)powers[i].getMagnitude();
        }

        indicateInvalidOperation();
        return (int)powers[i].getMagnitude();
    }

    public int removePower(int i)
    {
        if (i >= powers.Length || i < 0 || powers[i] == null)
        {
            indicateInvalidOperation();
            return 0;
        }

        if (powers[i].remPower())
        {
            return (int)powers[i].getMagnitude();
        }

        indicateInvalidOperation();
        return (int)powers[i].getMagnitude();
    }
}
