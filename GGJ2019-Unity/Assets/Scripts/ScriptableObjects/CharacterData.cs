using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;


public struct SummaryReview
{

    public int Grade { get; private set; }
    public string Review { get; private set; }

    public SummaryReview(int grade, string review) : this()
    {
        Grade = grade;
        Review = review;
    }

}

[CreateAssetMenu(menuName = "ScriptableObjects/CharacterData")]
public class CharacterData : ScriptableObject
{
    [SerializeField] private string _name;
    public string Name { get { return _name; } }

    [SerializeField] private string _address;
    public string Address
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

    [SerializeField] private Sprite _sprite;
    public Sprite Sprite { get; private set; }

    public int GetSatisfaction(RoomStatus status)
    {
        var satisfaction = _requirements.GetSatisfaction(status);
        return satisfaction;
    }

    public SummaryReview GetSummaryReview(int satisfaction)
    {
        int grade = 0;
        int requirementCount = _requirements.Requirements.Count;
        float gradeStep = satisfaction / (float)requirementCount;
        grade = Mathf.Clamp(Mathf.FloorToInt(gradeStep * requirementCount * 5 / requirementCount), 1, 5);
        return new SummaryReview(grade, _reviewDialogData.GetSummaryReview(grade));
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
        var summaryReview = GetSummaryReview(GetSatisfaction(status));
        return _realtimeFeedbackData.GetSprite(summaryReview.Grade);
    }

    public void StartListening()
    {
        foreach (var requirement in _requirements.Requirements)
        {
            requirement.StartListening();
        }
    }
}
