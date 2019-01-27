using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[CreateAssetMenu(menuName = "ScriptableObjects/CharacterData")]
public class CharacterData : ScriptableObject
{
    [SerializeField] private string _name;
    public string Name { get { return _name; } }

    [SerializeField] private RequirementGroup _requirements;

    [SerializeField] private FinalReviewData _reviewDialogData;

    [SerializeField] private RealtimeFeedbackData _realtimeFeedbackData;

    public float GetSatisfaction(RoomStatus status)
    {
        var satisfaction = _requirements.GetSatisfaction(status);
        Debug.Log("Current satisfaction is " + satisfaction);
        return satisfaction;
    }

    public string GetSummaryReview(int satisfaction)
    {
        int grade = 0;
        if (satisfaction <= 0)
        {
            grade = Random.Range(1, 2);
        }
        else if (satisfaction == 1)
        {
            grade = 3;
        }
        else if (satisfaction == 2)
        {
            grade = 4;
        }
        else if (satisfaction == 3)
        {
            grade = 5;
        }
        return _reviewDialogData.GetSummaryReview(grade);
    }

    public List<Review> GetSubReviews(RoomStatus conditions)
    {
        List<Review> _subReviews = new List<Review>();
        _requirements.Requirements.ForEach(r => r.GetReview(conditions));

        return _subReviews;
    }

    public AudioClip GetSadSound()
    {
        return _realtimeFeedbackData.SadClip;
    }

    public AudioClip GetHappySound()
    {
        return _realtimeFeedbackData.HappyClip;
    }

    public Sprite GetRealtimeFeedbackImage(RoomStatus status)
    {
        return _realtimeFeedbackData.GetSprite(GetSatisfaction(status));
    }

    public void StartListening()
    {
        foreach (var requirement in _requirements.Requirements)
        {
            requirement.StartListening();
        }
    }
}
