using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct RequirementsParam
{
    public float Wetness { get; private set; }
    public bool NeedLight { get; private set; }

    public RequirementsParam(float wetness, bool needLight)
    {
        Wetness = wetness;
        NeedLight = needLight;
    }
}

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

    public float GetSatisfaction(RequirementsParam param)
    {
        return 0f; //todo : work out the math to calculate the satisfaction
    }
}
