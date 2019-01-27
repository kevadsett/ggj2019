using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BooleanResponderComponent : MonoBehaviour {
    public BooleanRequirementType Type;
    public bool Inverse;

	void Start () {
        switch (Type)
        {
            case BooleanRequirementType.Water:
                EventManager.WaterChanged += EventManager_ValueChanged;
                break;
            case BooleanRequirementType.Light:
                EventManager.LightingChanged += EventManager_ValueChanged;
                break;
        }
        gameObject.SetActive(false);
    }
	
    void EventManager_ValueChanged(bool value)
    {
        if (Inverse)
        {
            value = !value;
        }
        gameObject.SetActive(value);
    }

}
