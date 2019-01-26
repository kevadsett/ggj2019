using System.Collections.Generic;
using UnityEngine;

namespace StateMachine
{
    public enum EGameState
    {
        Splash,
        Running,
        Review
    }

    public class GameStateMachine
    {
        private Dictionary<EGameState, IGameState> _stateList;
        private IGameState _currentState;

        public GameStateMachine(Dictionary<EGameState, IGameState> stateList, EGameState defaultState)
        {
            _stateList = stateList;
            ChangeState(defaultState);
        }

        public void Update(float dt)
        {
            if (_currentState != null)
            {
                _currentState.Update(dt);
            }
        }

        public void ChangeState(EGameState newState)
        {
            if (_currentState != null)
            {
                _currentState.OnExit();
            }

            if (_stateList.TryGetValue(newState, out _currentState))
            {
                _currentState.OnEnter();
            }
            else
            {
                throw new System.Exception("State \"" + newState + "\" doesn't exist in state machine");
            }
        }
    }
}
