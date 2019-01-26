using System;
using UnityEngine;

namespace StateMachine
{
    public class RunningScreenState : AbstractGameState
    {
        private float _timeRunning;
        private int _previousSecondsRunning = -1;
        private int _secondsRunning;
        private int _tenancyLength;


        public RunningScreenState(Transform uiParent, GameObject uiPrefab, Transform hudParent, int tenancyLength) : base(uiParent, uiPrefab, hudParent)
        {
            _tenancyLength = tenancyLength;
        }

        public override void Update(float dt)
        {
            _timeRunning += dt;
            _secondsRunning = Mathf.FloorToInt(_timeRunning);
            if (_secondsRunning != _previousSecondsRunning)
            {
                Debug.Log(_tenancyLength - _secondsRunning);

                _previousSecondsRunning = _secondsRunning;
                if (_secondsRunning >= _tenancyLength)
                {
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
        }
    }
}
