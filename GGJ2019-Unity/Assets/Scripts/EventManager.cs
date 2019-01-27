using System;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : UnityEngine.MonoBehaviour
{

    public static event Action<bool> LightingChanged;
    public static void Call_LightingChanged(bool isOn)
    {
        if (LightingChanged != null)
        {
            LightingChanged(isOn);
        }
    }

    public static event Action<bool> BloodChanged;
    public static void Call_BloodChanged(bool isOn)
    {
        if (BloodChanged != null)
        {
            BloodChanged(isOn);
        }
    }

    public static event Action<bool> FishChanged;
    public static void Call_FishChanged(bool isOn)
    {
        if (FishChanged != null)
        {
            FishChanged(isOn);
        }
    }

    public static event Action<bool> InsectChanged;
    public static void Call_InsectChanged(bool isOn)
    {
        if (InsectChanged != null)
        {
            InsectChanged(isOn);
        }
    }

    public static event Action<bool> MeatChanged;
    public static void Call_MeatChanged(bool isOn)
    {
        if (MeatChanged != null)
        {
            MeatChanged(isOn);
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
            Debug.Log("Broadcasting temperature change");
            TemperatureChanged(newTemperature);
        }
    }

    public static event Action<int> GameTimeChanged;
    public static void Call_GameTimeChanged(int newDay)
    {
        if (GameTimeChanged != null)
        {
            GameTimeChanged(newDay);
        }
    }

    public static event Action SomethingGotWorse;
    public static void Call_SomethingGotWorse()
    {
        if (SomethingGotWorse != null)
        {
            Debug.Log("Something got worse!");
            SomethingGotWorse();
        }
    }

    public static event Action SomethingGotBetter;
    public static void Call_SomethingGotBetter()
    {
        if (SomethingGotBetter != null)
        {
            Debug.Log("Something got better!");
            SomethingGotBetter();
        }
    }
}