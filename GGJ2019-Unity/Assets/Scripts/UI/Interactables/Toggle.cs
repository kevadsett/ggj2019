using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using StateMachine;

[RequireComponent(typeof(Image))]
public class Toggle : MonoBehaviour, IPointerClickHandler
{
    public enum ToggleType
    {
        Normal,
        OnOnly,
        OffOnly
    }
    [SerializeField] Sprite _falseImage;
    [SerializeField] Sprite _trueImage;
    [SerializeField] BooleanRequirementType _requirementType;
    [SerializeField] bool _startValue;
    [SerializeField] ToggleType _toggleType;

    private Image MyImage;
    private RoomStatus _roomStatus;

    void Start()
    {
        MyImage = GetComponent<Image>();
        MyImage.sprite = _startValue ? _trueImage : _falseImage;

        _roomStatus = (RoomStatus)(StateData.Get("room"));
        _roomStatus.SetBoolValue(_requirementType, _startValue);

        switch (_requirementType)
        {
            case BooleanRequirementType.Water:
                EventManager.WaterChanged += EventManager_ValueChanged;
                break;
            case BooleanRequirementType.Light:
                EventManager.LightingChanged += EventManager_ValueChanged;
                break;
        }
    }


    public void OnPointerClick(PointerEventData eventData)
    {
        bool value = false;
        _roomStatus.TryGetBoolValue(_requirementType, out value);
        switch (_toggleType)
        {
            case ToggleType.OffOnly:
                if (value == false)
                {
                    return;
                }
                break;
            case ToggleType.OnOnly:
                if (value)
                {
                    return;
                }
                break;
        }
        value = !value;

        switch (_requirementType)
        {
            case BooleanRequirementType.Light:
                EventManager.Call_LightingChanged(value);
                break;
            case BooleanRequirementType.Water:
                EventManager.Call_WaterChanged(value);
                break;
            default:
                throw new System.ArgumentException("non supported");
        }
    }

    void EventManager_ValueChanged(bool value)
    {
        MyImage.sprite = value ? _trueImage : _falseImage;
    }

}
