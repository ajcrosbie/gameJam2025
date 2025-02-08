class HorizontalMovement : Power
{
    public HorizontalMovement(int max, bool useable) : base(max, useable) {}

    public override float getMagnitude()
    {
        return energyStored * 5f;
    }
}
