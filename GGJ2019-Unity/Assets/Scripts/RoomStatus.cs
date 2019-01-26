using System;
using System.Collections.Generic;

public class RoomStatus
{
    Dictionary<BooleanRequirementType, bool> _booleanConditionAndValues;
    Dictionary<FloatRequirementType, float> _floatConditionAndValues;

    public Dictionary<FloatRequirementType, float> FloatConditionAndValues
    {
        get
        {
            return _floatConditionAndValues;
        }
    }

    public Dictionary<BooleanRequirementType, bool> BooleanConditionAndValues
    {
        get
        {
            return _booleanConditionAndValues;
        }
    }

    public RoomStatus(Dictionary<BooleanRequirementType, bool> booleanConditionAndValues, Dictionary<FloatRequirementType, float> floatConditionAndValues)
    {
        _booleanConditionAndValues = booleanConditionAndValues;
        _floatConditionAndValues = floatConditionAndValues;
    }

    public override string ToString()
    {
        return "dummy string";
    }
}
