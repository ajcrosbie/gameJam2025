using UnityEngine;

public class Battery : MonoBehaviour
{
    public int maxBatteries;   // Total available energy
    public Power[] powers;     // Array of powers
    private int energyPool;    // Current energy in the battery
    private GUIStyle currentStyle;

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
                newPower = powerObject.AddComponent<HorizontalMovement>();  // Change speed

            } else if (i == 1){
                newPower = powerObject.AddComponent<sightEnable>();  // Change Sight
            } else {
                newPower = powerObject.AddComponent<verticalMovement>();  // Change jump height
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
            if (powers[i] != null && !powers[i].GetIsOn())
            {
                powers[i].drawBars((powers.Length- i), (powers.Length- i));  // PowerTypeOffset = 0 since only one type for now TODO: No longer 0
            }
        }
        drawBars(1,2);
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
    public void drawBars(int powerIndex, int powerTypeOffset)
    {
        int barWidth = 40;   // Make the bars wider
        int barHeight = 10;  // Short bars for horizontal layout
        int spacing = 3;     // Small spacing between bars
        int verticalSpacing = 15;  // Space between power levels (closer together)
        int horizontalSpacing = 50; // Space between different power types

        // Align to the top-right corner of the screen
        int startX = 30 + (0) * horizontalSpacing;  // Moves power types to the left
        int startY = 10;  // Stacks batteries downward

        for (int i = 0; i < maxBatteries; i++)
        {
            Rect barRect = new Rect(startX, startY + i * (barHeight + spacing), barWidth, barHeight);
            Color barColor = (i < energyPool) ? Color.green : Color.grey;

            drawBar(barRect, barColor);
        }
    }

    Texture2D MakeTex( int width, int height, Color col )
    {
        Color[] pix = new Color[width * height];
        for( int i = 0; i < pix.Length; ++i )
        {
            pix[ i ] = col;
        }
        Texture2D result = new Texture2D( width, height );
        result.SetPixels( pix );
        result.Apply();
        return result;
    }
        private void drawBar(Rect rect, Color color)
        {
            InitStyles(color);
            GUI.Box(rect, "",currentStyle );
        }

        private void InitStyles(Color color)
    {
        currentStyle = new GUIStyle( GUI.skin.box );
        currentStyle.normal.background = MakeTex( 2, 2, color);
    }
}
