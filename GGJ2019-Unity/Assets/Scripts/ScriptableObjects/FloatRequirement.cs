using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using StateMachine;

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

    private int _previousGrade = int.MinValue;

    public override void StartListening()
    {
        switch (_requirementType)
        {
            case FloatRequirementType.Temperature:
                EventManager.TemperatureChanged += EventManager_ValueChanged;
                break;
        }
    }

    private void OnDestroy()
    {
        EventManager.TemperatureChanged -= EventManager_ValueChanged;
    }

    public override Review GetReview(RoomStatus conditions)
    {
        string toReturn = "";
        int grade = 1;
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

            if (_previousGrade != grade)
            {
                if (grade == 1)
                {
                    Debug.Log(_requirementType + " got better");
                    EventManager.Call_SomethingGotBetter();
                }
                else
                {
                    Debug.Log(_requirementType + " got worse");

                    EventManager.Call_SomethingGotWorse();
                }
                _previousGrade = grade;
            }
        }
        
        return new Review(toReturn, grade);

    }

    void EventManager_ValueChanged(float obj)
    {
        GetReview((RoomStatus)StateData.Get("room"));
    }

}
