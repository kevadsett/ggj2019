using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using StateMachine;

public class StarGroups : MonoBehaviour
{
    [SerializeField] Sprite _starImage;
    List<Image> _images = new List<Image>();

    private void Start()
    {
        foreach (Transform item in transform)
        {
            _images.Add(item.GetComponent<Image>());
        }

        ShowStars();
    }

    private void ShowStars()
    {
        RoomStatus status = StateData.Get("room") as RoomStatus;
        CharacterData character = StateData.Get("character") as CharacterData;

        int satisfaction = character.GetSatisfaction(status);
        SummaryReview summaryReview = character.GetSummaryReview(satisfaction);

        for (int i = 0; i < summaryReview.Grade; i++)
        {
            _images[i].sprite = _starImage;
        }

    }
}
