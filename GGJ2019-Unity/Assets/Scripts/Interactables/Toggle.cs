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

    private Image MyImage;

    void OnStart()
    {
        MyImage = GetComponent<Image>();
    }

    [SerializeField] BooleanRequirementType _requirementType;

    public void OnPointerClick(PointerEventData eventData)
    {
        RoomStatus status = (RoomStatus)(StateData.Get("room"));
        bool value = false;
        status.TryGetBoolValue(_requirementType, out value);

        MyImage.sprite = value ? _trueImage : _falseImage;

        switch (_requirementType)
        {
            case BooleanRequirementType.Light:
                EventManager.Call_LightingChanged(!value);
                break;
            case BooleanRequirementType.Blood:
                EventManager.Call_BloodChanged(!value);
                break;
            case BooleanRequirementType.Insect:
                EventManager.Call_InsectChanged(!value);
                break;
            case BooleanRequirementType.Meat:
                EventManager.Call_MeatChanged(!value);
                break;
            case BooleanRequirementType.Fish:
                EventManager.Call_FishChanged(!value);
                break;
            default:
                throw new System.ArgumentException("non supported");
        }
    }

}
