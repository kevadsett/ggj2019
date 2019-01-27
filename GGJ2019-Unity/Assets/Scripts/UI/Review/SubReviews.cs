using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubReviews : ReviewRelatedText
{
    protected override void SetText()
    {
        List<Review> subReviews = character.GetSubReviews(status);
        string textOfReviews = "";
        foreach (var item in subReviews)
        {
            textOfReviews += "- " + item.Dialog + "\n";
        }
        Debug.Log(textOfReviews);
        relatedText.text = textOfReviews;
    }
}
