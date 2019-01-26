using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public enum BooleanRequirementType
{
    Water,
    Light,
    Blood,
    Insect,
    Meat,
    Fish
}
[CreateAssetMenu(menuName = "ScriptableObjects/BooleanRequirement")]
public class BooleanRequirement : Requirement
{
    [SerializeField] BooleanRequirementType _type;
    [SerializeField] bool _expectedValue;
    [SerializeField] string _satisfiedDialog;
    [SerializeField] string _unsatisfiedDialog;

    public override Review GetReview(RoomStatus conditions)
    {
        bool metConditions;
        if (conditions.TryGetBoolValue(_type, out metConditions))
        {
            if (metConditions == _expectedValue)
            {
                string dialog = metConditions ? _satisfiedDialog : _unsatisfiedDialog;
                return new Review(dialog, metConditions ? 1 : -1);
            }
        }
        else
        {
            throw new System.Exception("Type " + _type + " doesn't exist in dictionary");
        }
        return new Review();
    }
}
