using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/CharacterData")]
public class CharacterData : ScriptableObject
{
    [SerializeField] private string _name;
    public string Name { get { return _name; } }

    [SerializeField] private Sprite _sprite;
    public Sprite Sprite { get { return _sprite; } }

    [SerializeField] private Requirements _requirements;

    [SerializeField] private ReviewDialogData _reviewDialogData;

    [SerializeField] private RealtimeFeedbackData _realtimeFeedbackData;

    public float GetSatisfaction(RequirementsParam param)
    {
        return _requirements.GetSatisfaction(param);
    }

    public Review GetReview(float satisfaction)
    {
        return _reviewDialogData.GetReview(satisfaction);
    }

    public AudioClip GetRealtimeFeedback(float satisfaction)
    {
        return _realtimeFeedbackData.GetAudioClip(satisfaction);
    }
}
