using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

[Serializable]
public struct FloatConditionAndValue
{
    [SerializeField] FloatRequirementType _type;
    [SerializeField] float _value;

    public float Value
    {
        get
        {
            return _value;
        }
        set
        {
            _value = value;
        }
    }

    public FloatRequirementType Type
    {
        get
        {
            return _type;
        }
    }

    public FloatConditionAndValue(FloatRequirementType type, float value)
    {
        _type = type;
        _value = value;
    }
}

[Serializable]
public struct BooleanConditionAndValue
{
    [SerializeField] BooleanRequirementType _type;
    [SerializeField] bool _value;

    public bool Value
    {
        get
        {
            return _value;
        }
        set
        {
            _value = value;
        }
    }

    public BooleanRequirementType Type
    {
        get
        {
            return _type;
        }
    }

    public BooleanConditionAndValue(BooleanRequirementType type, bool value)
    {
        _type = type;
        _value = value;
    }
}

public class RoomConditions
{
    List<BooleanConditionAndValue> _booleanConditionAndValues;
    List<FloatConditionAndValue> _floatConditionAndValues;

    public RoomConditions(List<BooleanConditionAndValue> booleanConditionAndValues, List<FloatConditionAndValue> floatConditionAndValues)
    {
        _booleanConditionAndValues = booleanConditionAndValues;
        _floatConditionAndValues = floatConditionAndValues;
    }

    public bool GetBooleanConditionValue(BooleanRequirementType type)
    {
        return _booleanConditionAndValues.First(c => c.Type == type).Value;
    }

    public float GetFloatConditionValue(FloatRequirementType type)
    {
        return _floatConditionAndValues.First(c => c.Type == type).Value;
    }

    public void SetBooleanConditionValue(BooleanRequirementType type, bool value)
    {
        BooleanConditionAndValue conditionAndValue = _booleanConditionAndValues.First(c => c.Type == type);
        conditionAndValue.Value = value;
    }

    public void SetFloatConditionValue(FloatRequirementType type, float value)
    {
        FloatConditionAndValue conditionAndValue = _floatConditionAndValues.First(c => c.Type == type);
        conditionAndValue.Value = value;
    }
}
