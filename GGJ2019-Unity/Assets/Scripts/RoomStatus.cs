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
        _floatConditionAndValues[type] = value;
    }

    public void SetBoolValue(BooleanRequirementType type, bool value)
    {
        _booleanConditionAndValues[type] = value;
    }

    public bool TryGetFloatValue(FloatRequirementType type, out float value)
    {
        return _floatConditionAndValues.TryGetValue(type, out value);
    }

    public bool TryGetBoolValue(BooleanRequirementType type, out bool value)
    {
        return _booleanConditionAndValues.TryGetValue(type, out value);
    }
}
