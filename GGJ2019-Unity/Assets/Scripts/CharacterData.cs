using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/CharacterData")]
public class CharacterData : ScriptableObject{
    [SerializeField] private string _name;
    public string Name { get { return _name; } }
    [SerializeField] private Sprite _sprite;
    public Sprite Sprite { get { return _sprite; } }
}
