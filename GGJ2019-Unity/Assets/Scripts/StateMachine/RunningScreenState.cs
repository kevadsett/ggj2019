using System;
using UnityEngine;
using System.Collections.Generic;

namespace StateMachine
{
    public class RunningScreenState : AbstractGameState
    {
        private float _timeRunning;
        private int _previousSecondsRunning = -1;
        private int _secondsRunning;
        private int _tenancyLength;

        private RoomStatus _roomStatus;

        public RunningScreenState(
            Transform uiParent,
            GameObject uiPrefab,
            Transform hudParent,
            int tenancyLength,
            AudioSource BGMAudioSource
        ) : base(uiParent, uiPrefab, hudParent)
        {
            _tenancyLength = tenancyLength;

            _roomStatus = new RoomStatus();
        }

        public override void OnEnter()
        {
            base.OnEnter();

            _roomStatus.SetFloatValue(FloatRequirementType.Temperature, 0);
            _roomStatus.SetFloatValue(FloatRequirementType.WaterLevel, 0);
            _roomStatus.SetBoolValue(BooleanRequirementType.Light, true);

            EventManager.LightingChanged += EventManager_LightingChanged;
            EventManager.WaterLevelChanged += EventManager_WaterLevelChanged;
            EventManager.TemperatureChanged += EventManager_TemperatureChanged;
        }


        public override void Update(float dt)
        {
            _timeRunning += dt;
            _secondsRunning = Mathf.FloorToInt(_timeRunning);
            if (_secondsRunning != _previousSecondsRunning)
            {
                _previousSecondsRunning = _secondsRunning;
                if (_secondsRunning >= _tenancyLength)
                {
                    StateData.Add("room", _roomStatus);
                    GameRunner.GameStateMachine.ChangeState(EGameState.Review);
                }
            }
        }

        public override void OnExit()
        {
            base.OnExit();
            _timeRunning = 0f;
            _secondsRunning = 0;
            _previousSecondsRunning = -1;

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