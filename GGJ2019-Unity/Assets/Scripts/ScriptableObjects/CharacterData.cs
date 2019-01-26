using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[CreateAssetMenu(menuName = "ScriptableObjects/CharacterData")]
public class CharacterData : ScriptableObject
{
    [SerializeField] private string _name;
    public string Name { get { return _name; } }

    [SerializeField] private Sprite _sprite;
    public Sprite Sprite { get { return _sprite; } }

    [SerializeField] private RequirementGroup _requirements;

    [SerializeField] private ReviewDialogData _reviewDialogData;

    [SerializeField] private RealtimeFeedbackData _realtimeFeedbackData;

    public float GetSatisfaction(RequirementsParam param)
    {
        return _requirements.GetSatisfaction(param);
    }

    public string GetSummaryReview(int grade)
    {
        return _reviewDialogData.GetSummaryReview(grade);
    }

    public List<Review> GetSubReviews(RoomStatus conditions)
    {
        List<Review> _subReviews = new List<Review>();
        _requirements.Requirements.ForEach(r => r.GetReview(conditions));

        return _subReviews;
    }

    public AudioClip GetRealtimeFeedback(float satisfaction)
    {
        return _realtimeFeedbackData.GetAudioClip(satisfaction);
    }
}
