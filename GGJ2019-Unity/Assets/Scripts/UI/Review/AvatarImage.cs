using StateMachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AvatarImage : MonoBehaviour
{
    [SerializeField] Image _image;
    [SerializeField] CharacterData _data;
    private void Start()
    {
        _image = GetComponent<Image>();
        _data = StateData.Get("character") as CharacterData;
    }

    void SetImage()
    {
        _image.sprite = _data.Sprite;
    }
}
