using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[CreateAssetMenu(menuName = "ScriptableObjects/RequirementGroup")]
public class RequirementGroup : ScriptableObject
{
    [SerializeField] List<Requirement> _requirements;

    public List<Requirement> Requirements
    {
        get
        {
            return _requirements;
        }
    }

    public int GetSatisfaction(RoomStatus status)
    {
        return _requirements.Sum(r => r.GetReview(status).Reward);
    }
}
