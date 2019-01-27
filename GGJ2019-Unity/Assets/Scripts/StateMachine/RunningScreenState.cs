using System;
using UnityEngine;
using System.Collections.Generic;

namespace StateMachine
{
    public class RunningScreenState : AbstractGameState
    {
        private float _timeSinceDayBegan;
        private int _previousSeconds = -1;
        private int _daysPassed;

        private GameSettings _gameSettings;

        private RoomStatus _roomStatus;

        public RunningScreenState(
            Transform uiParent,
            GameObject uiPrefab,
            Transform hudParent,
            GameSettings gameSettings,
            AudioSource BGMAudioSource
        ) : base(uiParent, uiPrefab, hudParent)
        {
            _gameSettings = gameSettings;

            _roomStatus = (RoomStatus)StateData.Get("room");
        }

        public override void OnEnter()
        {
            base.OnEnter();


            EventManager.LightingChanged += EventManager_LightingChanged;
            EventManager.WaterLevelChanged += EventManager_WaterLevelChanged;
            EventManager.TemperatureChanged += EventManager_TemperatureChanged;
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
        }

        void EventManager_LightingChanged(bool isOn)
        {
            _roomStatus.SetBoolValue(BooleanRequirementType.Light, isOn);
        }

        void EventManager_WaterLevelChanged(float newLevel)
        {
            _roomStatus.SetFloatValue(FloatRequirementType.WaterLevel, newLevel);
        }

        void EventManager_TemperatureChanged(float newTemperature)
        {
            _roomStatus.SetFloatValue(FloatRequirementType.Temperature, newTemperature);
        }

    }
}