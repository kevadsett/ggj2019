using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct RequirementsParam
{
    public float Wetness { get; private set; }

    public RequirementsParam(float wetness)
    {
        Wetness = wetness;
    }
}

[CreateAssetMenu(menuName = "ScriptableObjects/Requirements")]
public class Requirements : ScriptableObject
{
    [SerializeField]
    [Range(-1f, 1f)]
    private float _minWetness = 1f;
    [SerializeField]
    [Range(-1f, 1f)]
    private float _maxWetness = 1f;

    public float GetSatisfaction(RequirementsParam param)
    {
        return 0f; //todo : work out the math to calculate the satisfaction
    }
}
