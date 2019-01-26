using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

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
    [SerializeField] List<BooleanConditionAndValue> _booleanConditionAndValues;
    [SerializeField] List<FloatConditionAndValue> _floatConditionAndValues;

    public List<BooleanConditionAndValue> BooleanConditionAndValues
    {
        get
        {
            return _booleanConditionAndValues;
        }
    }

    public List<FloatConditionAndValue> FloatConditionAndValues
    {
        get
        {
            return _floatConditionAndValues;
        }
    }
}
