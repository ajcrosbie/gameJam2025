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
        if (energyStored >= maxMagnitude || !isOn)
        {
            return false;
        }
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

    public void drawBars(int offset)
    {
        if (!isOn) return;

        int barWidth = 40;
        int barHeight = 15;
        int spacing = 2;
        int horizontalSpacing = 50;

        int startX = Screen.width - (offset + 1) * horizontalSpacing;
        int startY = 10;

        for (int i = 0; i < maxMagnitude; i++)
        {
            Rect barRect = new Rect(startX + i * (barWidth + spacing), startY, barWidth, barHeight);
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
