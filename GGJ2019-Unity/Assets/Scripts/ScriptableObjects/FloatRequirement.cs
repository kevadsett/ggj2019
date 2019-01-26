using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public enum FloatRequirementType
{
    Temperature
}

[CreateAssetMenu(menuName = "ScriptableObjects/FloatRequirement")]
public class FloatRequirement : Requirement
{
    [SerializeField] private float _minValue;
    [SerializeField] private float _maxValue;
    [SerializeField] private FloatRequirementType _requirementType;

    [SerializeField] private string _tooHighDialog;
    [SerializeField] private string _tooLowDialog;
    [SerializeField] private string _withinRangeDialog;

    public override Review GetReview(RoomConditions conditions)
    {
        string toReturn;
        int grade;
        float roomValue = conditions.GetFloatConditionValue(_requirementType);

        if (roomValue < _minValue)
        {
            toReturn = _tooLowDialog;
            grade = -1;
        }
        else if (roomValue > _maxValue)
        {
            toReturn = _tooHighDialog;
            grade = -1;
        }
        else
        {
            toReturn = _withinRangeDialog;
            grade = 1;
        }
        return new Review(toReturn, grade);
    }
}
