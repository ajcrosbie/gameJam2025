using UnityEngine;

public abstract class Power
{
    private int energyStored;
    private int maxMagnitude;
    private bool isOn;

    public Power(int max, bool useable)
    {
        maxMagnitude = max;
        isOn = useable;
        energyStored = 0; // Initialize energy to 0
    }

    public bool addPower()
    {
        if (energyStored == maxMagnitude || !isOn)
        {
            return false;
        }
        energyStored++; // Increment stored energy
        return true;
    }

    public bool remPower()
    {
        if (energyStored == 0 || !isOn)
        {
            return false;
        }
        energyStored--; // Decrease stored energy
        return true;
    }

    // Abstract function - subclasses define how to interpret magnitude
    public abstract int getMagnitude();

    public void drawBars(int offset)
    {
        int barWidth = 20;   // Width of each bar
        int barHeight = 40;  // Height of each bar
        int spacing = 5;     // Space between bars
        int horizontalSpacing = 50; // Distance between power sets

        int startX = Screen.width - (offset + 1) * horizontalSpacing; // Stack power sets right to left
        int startY = 10; // Bars start at the top

        for (int i = 0; i < maxMagnitude; i++)
        {
            Rect barRect = new Rect(startX, startY + i * (barHeight + spacing), barWidth, barHeight);
            Color barColor = (i < getMagnitude()) ? Color.green : Color.gray;

            drawBar(barRect, barColor);
        }
    }

    private void drawBar(Rect rect, Color color)
    {
        GUI.color = color;
        GUI.Box(rect, GUIContent.none);
        GUI.color = Color.white; // Reset color after drawing
    }
}
