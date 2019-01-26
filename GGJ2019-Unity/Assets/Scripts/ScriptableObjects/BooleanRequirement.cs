using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public enum BooleanRequirementType
{
    Water
}

public class BooleanRequirement : Requirement
{
    [SerializeField] BooleanRequirementType _type;
    [SerializeField] bool _expectedValue;
    [SerializeField] string _satisfiedDialog;
    [SerializeField] string _unsatisfiedDialog;

    public override Review GetReview(RoomConditions conditions)
    {
        bool metCondtions = conditions.BooleanConditionAndValues.First(c => c.Type == _type).Value == _expectedValue;
        string dialog = metCondtions ? _satisfiedDialog : _unsatisfiedDialog;

        return new Review(dialog, metCondtions ? 1 : -1);
    }
}
