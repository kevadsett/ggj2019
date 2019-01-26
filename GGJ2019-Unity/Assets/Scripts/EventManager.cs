using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour {

    public static event System.Action<bool> LightingChanged;
    public static void Call_LightingChanged (bool isOn) {
        LightingChanged(isOn);
    }
}