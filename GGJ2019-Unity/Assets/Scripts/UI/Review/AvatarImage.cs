using StateMachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AvatarImage : MonoBehaviour
{
    [SerializeField] Image _image;
    CharacterData _data;
    private void Start()
    {
        _data = (CharacterData)StateData.Get("character");

        SetImage();
    }

    void SetImage()
    {
        _image.sprite = _data.Sprite;
    }
}
