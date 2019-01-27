using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CalendarUpdater : MonoBehaviour {

    public GameSettings GameSettings;
    public Sprite Circle;
    public List<Sprite> Crosses;
    public Sprite CircleAndCross;
    public List<Transform> CalendarSlots;
    private AudioSource _calendarSound;

    void Start () 
    {
        EventManager.GameTimeChanged += EventManager_GameTimeChanged;

        int circleIndex = GameSettings.TenancyLength - 1;
        var circleImage = CalendarSlots[circleIndex].gameObject.AddComponent<Image>();
        circleImage.sprite = Circle;
        _calendarSound = GameObject.Find("CalendarSound").GetComponent<AudioSource>();
    }

    private void OnDestroy()
    {
        EventManager.GameTimeChanged -= EventManager_GameTimeChanged;
    }

    void EventManager_GameTimeChanged(int newDay)
    {
        int crossIndex = newDay - 1;
        var crossObject = CalendarSlots[crossIndex].gameObject;
        if (newDay == GameSettings.TenancyLength)
        {
            crossObject.GetComponent<Image>().sprite = CircleAndCross;
            return;
        }
        if (crossObject != null)
        {
            var crossImage = crossObject.AddComponent<Image>();
            crossImage.sprite = Crosses[Random.Range(0, Crosses.Count)];
        }
        _calendarSound.Play();
    }

}
