using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using StateMachine;

public enum BooleanRequirementType
{
    Light,
    Water,
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
        string dialog = "";
        bool currentBoolStatus;
        bool meetsCondition;
        if (conditions.TryGetBoolValue(_type, out currentBoolStatus))
        {

            meetsCondition = currentBoolStatus == _requiredValue;
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
                    _initialised = true;
                }
               
            }
        }
        else
        {
            throw new System.Exception("Type " + _type + " doesn't exist in dictionary");
        }
        dialog = meetsCondition ? _satisfiedDialog : _unsatisfiedDialog;
        return new Review(dialog, meetsCondition ? 1 : -1);
    }

    void EventManager_ValueChanged(bool obj)
    {
        GetReview((RoomStatus)StateData.Get("room"));
    }

}
