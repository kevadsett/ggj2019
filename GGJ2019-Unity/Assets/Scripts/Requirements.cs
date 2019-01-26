using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/Requirements")]
public class Requirements : ScriptableObject
{
    [SerializeField]
    [Range(0f, 1f)]
    private float _wetness = 0f;
    public float Wetness { get { return _wetness; } }

    public float RequirementMet(float wetness)
    {
        return 0f;
    }
}
