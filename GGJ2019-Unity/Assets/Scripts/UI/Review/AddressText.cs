using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddressText : ReviewRelatedText
{
    protected override void SetText()
    {
        relatedText.text = character.Address;
    }
}
