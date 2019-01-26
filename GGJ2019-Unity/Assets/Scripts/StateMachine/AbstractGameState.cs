using UnityEngine;

namespace StateMachine
{
    public abstract class AbstractGameState : IGameState
    {
        private Transform _uiParent;
        private GameObject _uiPrefab;
        private GameObject _uiObject;
        public AbstractGameState(Transform uiParent, GameObject uiPrefab)
        {
            _uiParent = uiParent;
            _uiPrefab = uiPrefab;
        }

        public virtual void OnEnter()
        {
            _uiObject = Object.Instantiate(_uiPrefab, _uiParent);
        }

        public virtual void OnExit()
        {
            Object.Destroy(_uiObject);
        }

        // implement in subclass if needed
        public abstract void Update(float dt);
    }
}
