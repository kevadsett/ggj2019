using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Requirement : ScriptableObject
{
    public abstract Review GetReview(RoomStatus conditions);
    public abstract void StartListening();
}

public struct Review
{
    public string Dialog { get; private set; }
    public int Reward { get; private set; }

    public Review(string dialog, int reward)
    {
        Dialog = dialog;
        Reward = reward;
    }
}
