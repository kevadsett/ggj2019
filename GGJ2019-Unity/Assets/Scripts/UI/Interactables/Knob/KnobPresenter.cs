﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnobPresenter
{
    const float VALUE_CHANGE_PER_XDIFF = 0.002f;
    const float MAX_VALUE = 1f;

    KnobView _view;
    float _currentValue = 0f;
    FloatRequirementType _floatRequirementType;


    public KnobPresenter(KnobView view, FloatRequirementType floatRequirementType)
    {
        _view = view;
        _floatRequirementType = floatRequirementType;
    }

    public void OnUserDrag(float xDiff)
    {
        _currentValue += xDiff * VALUE_CHANGE_PER_XDIFF;
        _currentValue = Mathf.Clamp01(_currentValue);

        _view.OnValueChange(_currentValue / MAX_VALUE);
    }

    public void OnDeactivate(GameObject gameObject)
    {
        // because the knob is backwards and game jam
        _currentValue = 1 - _currentValue;
        switch (_floatRequirementType)
        {
            case FloatRequirementType.Temperature:
                EventManager.Call_TemperatureChanged(_currentValue);
                break;
            default:
                throw new ArgumentException("we do not support that type (" + _floatRequirementType + ") yet, implement yourself noob");
        }
        gameObject.SetActive(false);
    }
}
