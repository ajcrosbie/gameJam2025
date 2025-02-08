using UnityEngine;

public class Battery
{
    public int maxBatteries;
    public int usedBatteries;
    private Power[] powers;

    public Battery(int power)
    {
        maxBatteries = power;
        powers = new Power[maxBatteries]; // Initialize array
        usedBatteries = 0;
    }

    private void draw()
    {
        if (powers == null) return; // Safety check
        
        for (int i = 0; i < powers.Length; i++)
        {
            if (powers[i] != null) // Check for null before calling method
            {
                powers[i].drawBars(i); // Offset each power's bars horizontally
            }
        }
    }

    private void indicateInvalidOpperation()
    {
        Debug.LogError("Invalid operation attempted on Battery.");
    }

    public int addPower(int i)
    {
        if (i < 0 || i >= powers.Length || powers[i] == null)
        {
            indicateInvalidOpperation();
            return 0;
        }
        if (usedBatteries == maxBatteries)
        {
            indicateInvalidOpperation();
            return powers[i].getMagnitude();
        }
        if (powers[i].addPower())
        {
            usedBatteries++;
            return powers[i].getMagnitude();
        }
        indicateInvalidOpperation();
        return powers[i].getMagnitude();
    }

    public int removePower(int i)
    {
        if (i < 0 || i >= powers.Length || powers[i] == null)
        {
            indicateInvalidOpperation();
            return 0;
        }
        if (usedBatteries == 0)
        {
            indicateInvalidOpperation();
            return powers[i].getMagnitude();
        }
        if (powers[i].remPower())
        {
            usedBatteries--;
            return powers[i].getMagnitude();
        }
        indicateInvalidOpperation();
        return powers[i].getMagnitude();
    }


}
