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
            powerObject.transform.position = new Vector3(powerObject.transform.position.x - i * 10,powerObject.transform.position.y,powerObject.transform.position.z);
            Power newPower;
            if (i==0){
                newPower = powerObject.AddComponent<HorizontalMovement>();  // Example subclass

            } else{
                Debug.Log("Sight");
                newPower = powerObject.AddComponent<sightEnable>();  // Change Sight
            }

            newPower.Initialize(3, isOnList[i]);
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
                powers[i].drawBars(i, i);  // PowerTypeOffset = 0 since only one type for now TODO: No longer 0
            }
        }
    }

    public bool addPower(int index)
    {
        if (index >= powers.Length || powers[index] == null || energyPool <= 0)
        {
            return false;
        }

        if (powers[index].addPower())
        {
            energyPool--;  // Reduce available energy
            return true;

        }

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
