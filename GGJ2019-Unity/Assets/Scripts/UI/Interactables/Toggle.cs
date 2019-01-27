using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using StateMachine;

[RequireComponent(typeof(Image))]
public class Toggle : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] Sprite _falseImage;
    [SerializeField] Sprite _trueImage;
    [SerializeField] BooleanRequirementType _requirementType;
    [SerializeField] bool _startValue;

    private Image MyImage;
    private RoomStatus _roomStatus;

    void Start()
    {
        MyImage = GetComponent<Image>();
        MyImage.sprite = _startValue ? _trueImage : _falseImage;

        _roomStatus = (RoomStatus)(StateData.Get("room"));
        _roomStatus.SetBoolValue(_requirementType, _startValue);
    }


    public void OnPointerClick(PointerEventData eventData)
    {
        bool value = false;
        _roomStatus.TryGetBoolValue(_requirementType, out value);
        value = !value;
        MyImage.sprite = value ? _trueImage : _falseImage;

        switch (_requirementType)
        {
            case BooleanRequirementType.Light:
                EventManager.Call_LightingChanged(value);
                break;
            case BooleanRequirementType.Blood:
                EventManager.Call_BloodChanged(value);
                break;
            case BooleanRequirementType.Insect:
                EventManager.Call_InsectChanged(value);
                break;
            case BooleanRequirementType.Meat:
                EventManager.Call_MeatChanged(value);
                break;
            case BooleanRequirementType.Fish:
                EventManager.Call_FishChanged(value);
                break;
            default:
                throw new System.ArgumentException("non supported");
        }
    }

}
