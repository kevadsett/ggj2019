using StateMachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[RequireComponent(typeof(Text))]
public abstract class ReviewRelatedText : MonoBehaviour
{
    protected Text relatedText;
    protected RoomStatus status;
    protected CharacterData character;

    private void Start()
    {
        relatedText = GetComponent<Text>();
        character = StateData.Get("character") as CharacterData;
        status = StateData.Get("room") as RoomStatus;

        SetText();
    }

    protected abstract void SetText();
}
