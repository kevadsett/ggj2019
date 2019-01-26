using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/SpeechData")]
public class SpeechData : ScriptableObject
{
    [SerializeField] private AudioClip _happyClip;
    [SerializeField] private AudioClip _sadClip;

    public AudioClip GetAudioClip(float satisfaction)
    {
        //crude implemention that only has 2 audio clip, to be modified if need a better implementation
        return satisfaction > 0.5 ? _happyClip : _sadClip;
    }
}
