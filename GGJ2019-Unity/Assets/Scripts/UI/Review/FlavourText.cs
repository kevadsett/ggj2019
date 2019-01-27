using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlavourText : ReviewRelatedText
{
    protected override void SetText()
    {
        relatedText.text = character.FlavouredText;
    }
}
