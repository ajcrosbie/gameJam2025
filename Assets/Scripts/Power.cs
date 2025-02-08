using UnityEngine;

public abstract class Power : MonoBehaviour
{
    protected int energyStored;
    private int maxMagnitude;
    private bool isOn;

    // Constructor-like initializer (Unity doesn't support constructors in MonoBehaviour)
    public void Initialize(int max, bool useable)
    {
        maxMagnitude = max;
        isOn = useable;
        energyStored = 0;
    }

    public void setOn(bool i)
    {
        isOn = i;
    }

    public bool addPower()
    {
        Debug.Log(energyStored);
        if (energyStored >= maxMagnitude || !isOn)
        {
            return false;
        }
        Debug.Log(energyStored);

        energyStored++;
        return true;
    }

    public bool remPower()
    {
        if (energyStored <= 0 || !isOn)
        {
            return false;
        }
        energyStored--;
        return true;
    }

    public abstract float getMagnitude();

    public void drawBars(int powerIndex, int powerTypeOffset)
    {
        int barWidth = 40;   // Make the bars wider
        int barHeight = 10;  // Short bars for horizontal layout
        int spacing = 3;     // Small spacing between bars
        int verticalSpacing = 15;  // Space between power levels (closer together)
        int horizontalSpacing = 50; // Space between different power types

        // Align to the top-right corner of the screen
        int startX = Screen.width - (powerTypeOffset + 1) * horizontalSpacing;  // Moves power types to the left
        int startY = 10 + powerIndex * verticalSpacing;  // Stacks batteries downward

        for (int i = 0; i < maxMagnitude; i++)
        {
            Rect barRect = new Rect(startX, startY + i * (barHeight + spacing), barWidth, barHeight);
            Color barColor = (i < energyStored) ? Color.green : Color.gray;

            drawBar(barRect, barColor);
        }
    }


    private void drawBar(Rect rect, Color color)
    {
        GUI.color = color;
        GUI.Box(rect, GUIContent.none);
        GUI.color = Color.white;
    }

    public int GetEnergyStored() => energyStored;
    public int GetMaxMagnitude() => maxMagnitude;
}
