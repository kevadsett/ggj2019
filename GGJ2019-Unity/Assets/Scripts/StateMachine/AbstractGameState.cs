using UnityEngine;

namespace StateMachine
{
    public class AbstractGameState : IGameState
    {
        private Transform _uiParent;
        private GameObject _uiPrefab;
        private GameObject _uiObject;
        public AbstractGameState(Transform uiParent, GameObject uiPrefab)
        {
            _uiParent = uiParent;
            _uiPrefab = uiPrefab;
        }

        public void OnEnter()
        {
            _uiObject = Object.Instantiate(_uiPrefab, _uiParent);
        }

        public void OnExit()
        {
            Object.Destroy(_uiObject);
        }

        // implement in subclass if needed
        public void Update(float dt)
        {
        }
    }
}
