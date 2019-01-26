using System;
using UnityEngine;

namespace StateMachine
{
    public class RunningScreenState : AbstractGameState
    {
        private float _timeRunning;
        private readonly DateTime StartDate = new DateTime(2019, 1, 1);
        private int PreviousSecondsRunning;
        private int SecondsRunning;
        private DateTime CurrentDate;

        public RunningScreenState(Transform uiParent, GameObject uiPrefab) : base(uiParent, uiPrefab)
        {
        }

        public override void OnEnter()
        {
            base.OnEnter();
            CurrentDate = new DateTime(2019, 1, 1);
        }

        public override void Update(float dt)
        {
            _timeRunning += dt;
            SecondsRunning = Mathf.FloorToInt(_timeRunning);
            if (SecondsRunning != PreviousSecondsRunning)
            {
                CurrentDate = CurrentDate.AddDays(1);
                PreviousSecondsRunning = SecondsRunning;

                Debug.Log(CurrentDate.ToString());
            }
        }
    }
}
