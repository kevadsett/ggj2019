using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using StateMachine;

public enum BooleanRequirementType
{
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
    [SerializeField] bool _requiredValue;
    [SerializeField] string _satisfiedDialog;
    [SerializeField] string _unsatisfiedDialog;

    private bool _previouslyMetConditions;
    private bool test;
    private bool _initialised;

    public override void StartListening()
    {
        switch(_type)
        {
            case BooleanRequirementType.Light:
                Debug.Log("Listening for light changes");
                EventManager.LightingChanged += EventManager_ValueChanged;
                break;
        }
    }

    private void OnDestroy()
    {
        EventManager.LightingChanged -= EventManager_ValueChanged;
    }

    public override Review GetReview(RoomStatus conditions)
    {
        bool currentBoolStatus;
        if (conditions.TryGetBoolValue(_type, out currentBoolStatus))
        {
            Debug.Log("currentBoolStatus: " + currentBoolStatus + ", _expectedValue: " + _requiredValue);

            bool meetsCondition = currentBoolStatus == _requiredValue;
            Debug.Log("meetsCondition: " + meetsCondition + ", previouslyMet: " + _previouslyMetConditions + ", initialised: " + _initialised);
            if (meetsCondition != _previouslyMetConditions || _initialised == false)
            {
                if (meetsCondition == true)
                {
                    Debug.Log(_type + " got better");
                    EventManager.Call_SomethingGotBetter();
                }
                else
                {
                    Debug.Log(_type + " got worse");
                    EventManager.Call_SomethingGotWorse();
                }
                _previouslyMetConditions = meetsCondition;

                if (meetsCondition)
                {
                    string dialog = meetsCondition ? _satisfiedDialog : _unsatisfiedDialog;

                    _initialised = true;

                    return new Review(dialog, meetsCondition ? 1 : -1);
                }
               
            }
        }
        else
        {
            throw new System.Exception("Type " + _type + " doesn't exist in dictionary");
        }
        return new Review();
    }

    void EventManager_ValueChanged(bool obj)
    {
        Debug.Log("Heard a light change");
        GetReview((RoomStatus)StateData.Get("room"));
    }

}
