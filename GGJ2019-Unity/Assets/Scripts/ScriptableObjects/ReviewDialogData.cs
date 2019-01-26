using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "ScriptableObjects/DialogData")]
public class ReviewDialogData : ScriptableObject
{
    [SerializeField] private string[] _dialogues;

    public string GetSummaryReview(int finalGrade)
    {
        Debug.Assert(_dialogues.Length <= GameConfig.MAX_REVIEW_GRADE);

        return _dialogues[finalGrade];
    }
}
