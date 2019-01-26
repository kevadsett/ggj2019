using System;
public class RoomStatus
{
    public float WaterLevel;
    public float Temperature;
    public bool Light;

    public RoomStatus()
    {
    }

    public override string ToString()
    {
        return "WaterLevel: " + WaterLevel + ", Temperature: " + Temperature + ", Light: " + (Light ? "Light" : "Dark");
    }
}
