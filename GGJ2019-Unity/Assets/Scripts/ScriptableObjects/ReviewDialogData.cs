using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct Review
{
    public string Dialog { get; private set; }
    public int Level { get; private set; }

    public Review(string dialog, int level) : this()
    {
        Dialog = dialog;
        Level = level;
    }

}

[CreateAssetMenu(menuName = "ScriptableObjects/DialogData")]
public class ReviewDialogData : ScriptableObject
{
    [SerializeField] private string[] _dialogues;

    public Review GetReview(float satisfaction)
    {
        Debug.Assert(satisfaction <= 1f);
        Debug.Assert(_dialogues.Length <= GameConfig.MAX_REVIEW_GRADE);

        int level = (int)(satisfaction / (1f / GameConfig.MAX_REVIEW_GRADE));
        return new Review(_dialogues[level], level);
    }
}
