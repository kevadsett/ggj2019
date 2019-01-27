using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/RealtimeFeedbackData")]
public class RealtimeFeedbackData : ScriptableObject
{
    [SerializeField] public AudioClip HappyClip;
    [SerializeField] public AudioClip SadClip;
    [SerializeField] private Sprite _happyAvatar;
    [SerializeField] private Sprite _neutralAvatar;
    [SerializeField] private Sprite _sadAvatar;

    public Sprite GetSprite(float satisfaction)
    {
        if (satisfaction < 2)
        {
            return _sadAvatar;
        }

        if (satisfaction < 4)
        {
            return _neutralAvatar;
        }

        return _happyAvatar;
    }
}
