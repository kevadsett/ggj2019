using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public enum FloatRequirementType
{
    WaterLevel,
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

    public override Review GetReview(RoomStatus conditions)
    {
        string toReturn;
        int grade;
        float roomValue;
        if (conditions.TryGetFloatValue(_requirementType, out roomValue))
        {
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
        return new Review();
    }
}
