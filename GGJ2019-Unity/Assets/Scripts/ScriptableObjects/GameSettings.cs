using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/GameSettings")]
public class GameSettings : ScriptableObject
{
    [SerializeField] private int _tenancyLength;
    public int TenancyLength { get { return _tenancyLength; } }

    [SerializeField] private int _secondsPerDay;
    public int SecondsPerDay { get { return _secondsPerDay; } }
}
