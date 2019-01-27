using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[CreateAssetMenu(menuName = "ScriptableObjects/CharacterData")]
public class CharacterData : ScriptableObject
{
    [SerializeField] private string _name;
    public string Name { get { return _name; } }

    [SerializeField] private string _address;
    public string Location
    {
        get
        {
            return _address;
        }
    }

    [SerializeField] private string _occupation;
    public string Occupation { get { return _occupation; } }

    [SerializeField] private string _flavouredText;
    public string FlavouredText { get { return _flavouredText; } }

    [SerializeField] private RequirementGroup _requirements;

    [SerializeField] private FinalReviewData _reviewDialogData;

    [SerializeField] private RealtimeFeedbackData _realtimeFeedbackData;


    public float GetSatisfaction(RoomStatus status)
    {
        return _requirements.GetSatisfaction(status);
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

    public AudioClip GetRealtimeFeedbackAudio(RoomStatus status)
    {
        return _realtimeFeedbackData.GetAudioClip(GetSatisfaction(status));
    }

    public Sprite GetRealtimeFeedbackImage(RoomStatus status)
    {
        return _realtimeFeedbackData.GetSprite(GetSatisfaction(status));
    }
}
