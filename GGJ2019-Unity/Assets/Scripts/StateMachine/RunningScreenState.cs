﻿using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

namespace StateMachine
{
    public class RunningScreenState : AbstractGameState
    {
        private float _timeSinceDayBegan;
        private int _previousSeconds = -1;
        private int _daysPassed;

        private GameSettings _gameSettings;

        private RoomStatus _roomStatus;

        private List<CharacterData> _characters;

        private CharacterData _currentCharacter;

        private Image Avatar;
        private AudioSource FeedbackAudio;

        public RunningScreenState(
            Transform uiParent,
            GameObject uiPrefab,
            Transform hudParent,
            GameSettings gameSettings,
            List<CharacterData> characters
        ) : base(uiParent, uiPrefab, hudParent)
        {
            _gameSettings = gameSettings;
            _characters = characters;

            _roomStatus = (RoomStatus)StateData.Get("room");
        }

        public override void OnEnter()
        {
            base.OnEnter();

            _currentCharacter = _characters[Random.Range(0, _characters.Count)];

            Avatar = GameObject.Find("Avatar").GetComponent<Image>();
            FeedbackAudio = GameObject.Find("FeedbackAudio").GetComponent<AudioSource>();

            Avatar.sprite = _currentCharacter.GetRealtimeFeedbackImage(_roomStatus);

            Debug.Log("Listening to events");
            EventManager.LightingChanged += EventManager_LightingChanged;
            EventManager.WaterLevelChanged += EventManager_WaterLevelChanged;
            EventManager.TemperatureChanged += EventManager_TemperatureChanged;
            EventManager.SomethingGotBetter += ReactToSomethingGettingBetter;
            EventManager.SomethingGotWorse += ReactToSomethingGettingWorse;

            _currentCharacter.StartListening();

        }

        public override void Update(float dt)
        {
            _timeSinceDayBegan += dt;
            var secondsPassedSinceDayBegan = Mathf.FloorToInt(_timeSinceDayBegan);
            if (secondsPassedSinceDayBegan == _previousSeconds)
            {
                return;
            }

            _previousSeconds = secondsPassedSinceDayBegan;

            if (secondsPassedSinceDayBegan != _gameSettings.SecondsPerDay)
            {
                return;
            }

            _daysPassed++;
            _timeSinceDayBegan = secondsPassedSinceDayBegan = 0;

            EventManager.Call_GameTimeChanged(_daysPassed);

            if (_daysPassed > _gameSettings.TenancyLength)
            {
                StateData.Add("room", _roomStatus);
                GameRunner.GameStateMachine.ChangeState(EGameState.Review);
            }
        }

        public override void OnExit()
        {
            base.OnExit();
            _timeSinceDayBegan = 0f;
            _daysPassed = 0;
            _previousSeconds = -1;

            EventManager.TemperatureChanged -= EventManager_TemperatureChanged;
            EventManager.WaterLevelChanged -= EventManager_WaterLevelChanged;
            EventManager.LightingChanged -= EventManager_LightingChanged;
            EventManager.SomethingGotBetter -= ReactToSomethingGettingBetter;
            EventManager.SomethingGotWorse -= ReactToSomethingGettingWorse;
        }

        void EventManager_LightingChanged(bool isOn)
        {
            Debug.Log("Lighting changed to " + (isOn ? "on" : "off"));
            _roomStatus.SetBoolValue(BooleanRequirementType.Light, isOn);
        }

        void EventManager_WaterLevelChanged(float newLevel)
        {
            Debug.Log("Water level changed to " + newLevel);

            _roomStatus.SetFloatValue(FloatRequirementType.WaterLevel, newLevel);
        }

        void EventManager_TemperatureChanged(float newTemperature)
        {
            Debug.Log("Temperature changed to " + newTemperature);
            _roomStatus.SetFloatValue(FloatRequirementType.Temperature, newTemperature);
        }

        void ReactToValueChanged()
        {
            var newSprite = _currentCharacter.GetRealtimeFeedbackImage(_roomStatus);
            Avatar.sprite = newSprite;
        }

        void ReactToSomethingGettingWorse()
        {
            FeedbackAudio.clip = _currentCharacter.GetSadSound();
            FeedbackAudio.Play();
        }

        void ReactToSomethingGettingBetter()
        {
            FeedbackAudio.clip = _currentCharacter.GetHappySound();
            FeedbackAudio.Play();
        }
    }
}