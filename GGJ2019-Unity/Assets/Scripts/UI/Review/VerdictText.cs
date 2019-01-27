using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

[RequireComponent(typeof(Text))]
public class VerdictText : ReviewRelatedText
{
    protected override void SetText()
    {
        int satisfaction = character.GetSatisfaction(status);
        relatedText.text = character.GetSummaryReview(satisfaction).Review;
    }
}
