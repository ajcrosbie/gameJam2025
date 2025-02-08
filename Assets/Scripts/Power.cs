public abstract class Power{
    private int magnitude;
    private int maxMagnitude;
    private bool on;
    public Power(int max, bool useable){
        maxMagnitude = max;
        on = useable;
    }
    public bool addPower(){

        if (magnitude == maxMagnitude || !on){
            return false;
        }
        addToPowerSideEffect();
        return true;
    }
    protected abstract void addToPowerSideEffect();
    public int getMagnitude(){
        return magnitude;
    }
}