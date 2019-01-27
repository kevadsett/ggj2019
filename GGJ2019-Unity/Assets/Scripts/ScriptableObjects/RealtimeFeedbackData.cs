using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/RealtimeFeedbackData")]
public class RealtimeFeedbackData : ScriptableObject
{
    [SerializeField] private AudioClip _happyClip;
    [SerializeField] private AudioClip _sadClip;
    [SerializeField] private Sprite _happyAvatar;
    [SerializeField] private Sprite _neutralAvatar;
    [SerializeField] private Sprite _sadAvatar;

    public AudioClip GetAudioClip(float satisfaction)
    {
        //crude implemention that only has 2 audio clip, to be modified if need a better implementation
        return satisfaction > 0.5 ? _happyClip : _sadClip;
    }

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
