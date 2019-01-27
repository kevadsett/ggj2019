using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OccupationText : ReviewRelatedText
{
    protected override void SetText()
    {
        relatedText.text = character.Occupation;
    }
}
