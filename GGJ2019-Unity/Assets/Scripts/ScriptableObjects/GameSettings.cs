using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/GameSettings")]
public class GameSettings : ScriptableObject
{
    [SerializeField] private int _tenancyLength;
    public int TenancyLength { get { return _tenancyLength; } }
}
