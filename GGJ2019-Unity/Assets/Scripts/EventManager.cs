using System;
using System.Collections.Generic;

public class EventManager : UnityEngine.MonoBehaviour {

    public static event Action<bool> LightingChanged;
    public static void Call_LightingChanged (bool isOn) {
        if (LightingChanged != null)
        {
            LightingChanged(isOn);
        }
    }

    public static event Action<float> WaterLevelChanged;
    public static void Call_WaterLevelChanged(float newLevel)
    {
        if (WaterLevelChanged != null)
        {
            WaterLevelChanged(newLevel);
        }
    }

    public static event Action<float> TemperatureChanged;
    public static void Call_TemperatureChanged(float newTemperature)
    {
        if (TemperatureChanged != null)
        {
            TemperatureChanged(newTemperature);
        }
    }
}