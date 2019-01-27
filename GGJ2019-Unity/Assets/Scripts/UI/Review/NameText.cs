using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NameText : ReviewRelatedText
{
    protected override void SetText()
    {
        relatedText.text = character.Name;
    }
}
