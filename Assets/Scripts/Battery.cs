using UnityEngine;

public class Battery : MonoBehaviour
{
    public int maxBatteries;   // Total available energy
    public Power[] powers;     // Array of powers
    private int energyPool;    // Current energy in the battery

    public void InitializeBattery(int powerSlots, bool[] isOnList)
    {
        maxBatteries = powerSlots;
        energyPool = maxBatteries; // Start with full energy

        powers = new Power[isOnList.Length];

        for (int i = 0; i < isOnList.Length; i++)
        {
            GameObject powerObject = new GameObject($"Power_{i}");  // Create a new GameObject for each Power
            powerObject.transform.parent = this.transform;  // Attach to the Battery GameObject
            Power newPower = powerObject.AddComponent<HorizontalMovement>();  // Example subclass

            newPower.Initialize(2, isOnList[i]);
            powers[i] = newPower;
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
                powers[i].drawBars(i, 0);  // PowerTypeOffset = 0 since only one type for now
            }
        }
    }

    public bool addPower(int index)
    {
        Debug.Log(index);
        if (index >= powers.Length || powers[index] == null || energyPool <= 0)
        {
            Debug.Log(index);
            return false;
        }

        if (powers[index].addPower())
        {
            energyPool--;  // Reduce available energy
            return true;
        }
        Debug.Log(index);

        return false;
    }

    public bool removePower(int index)
    {
        if (index >= powers.Length || index < 0 || powers[index] == null)
        {
            return false;
        }

        if (powers[index].remPower())
        {
            energyPool++;  // Return energy to the pool
            return true;
        }

        return false;
    }
}
