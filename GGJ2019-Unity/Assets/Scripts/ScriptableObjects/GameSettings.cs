﻿using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/GameSettings")]
public class GameSettings : ScriptableObject
{
    [SerializeField] private int _tenancyLength;
    public int TenancyLength { get { return _tenancyLength; } }

    [SerializeField] private int _secondsPerDay;
    public int SecondsPerDay { get { return _secondsPerDay; } }

    [SerializeField] private int _dayToStartUrgentMusic;
    public int DayToStartUrgentMusic { get { return _dayToStartUrgentMusic; } }

    [SerializeField] private AudioClip _tensionClip;
    public AudioClip TensionClip { get { return _tensionClip; } }
}
