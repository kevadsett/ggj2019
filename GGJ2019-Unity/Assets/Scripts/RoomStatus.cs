using System;
using System.Collections.Generic;

public class RoomStatus
{
    Dictionary<BooleanRequirementType, bool> _booleanConditionAndValues = new Dictionary<BooleanRequirementType, bool>();
    Dictionary<FloatRequirementType, float> _floatConditionAndValues = new Dictionary<FloatRequirementType, float>();

    public override string ToString()
    {
        return "dummy string";
    }

    public void SetFloatValue(FloatRequirementType type, float value)
    {
        if (_floatConditionAndValues.ContainsKey(type))
        {
            _floatConditionAndValues[type] = value;
        }
        else
        {
            _floatConditionAndValues.Add(type, value);
        }
    }

    public void SetBoolValue(BooleanRequirementType type, bool value)
    {
        if (_booleanConditionAndValues.ContainsKey(type))
        {
            _booleanConditionAndValues[type] = value;
        }
        else
        {
            _booleanConditionAndValues.Add(type, value);
        }
    }
}
