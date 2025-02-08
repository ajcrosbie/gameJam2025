class HorizontalMovement : Power
{
    public override float getMagnitude()
    {
        return energyStored * 5f;
    }
}
