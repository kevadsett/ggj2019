using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct Review
{
    public string Dialog { get; private set; }
    public int Level { get; private set; }
    public AudioClip AudioClip { get; private set; }

    public Review(string dialog, int level, AudioClip audioClip) : this()
    {
        Dialog = dialog;
        Level = level;
        AudioClip = audioClip;
    }

}

[CreateAssetMenu(menuName = "ScriptableObjects/DialogData")]
public class ReviewDialogData : ScriptableObject
{
    [SerializeField] private string[] _dialogues;
    [SerializeField] private SpeechData _speechData;
    public Review GetReview(float satisfaction)
    {
        Debug.Assert(satisfaction <= 1f);
        Debug.Assert(_dialogues.Length <= GameConfig.MAX_REVIEW_GRADE);

        int level = (int)(satisfaction / (1f / GameConfig.MAX_REVIEW_GRADE));
        return new Review(_dialogues[level], level, _speechData.GetAudioClip(satisfaction));
    }
}
