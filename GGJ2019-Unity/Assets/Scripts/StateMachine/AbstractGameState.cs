using UnityEngine;

namespace StateMachine
{
    public abstract class AbstractGameState : IGameState
    {
        protected Transform _hudParent;

        private Transform _uiParent;
        private GameObject _uiPrefab;
        private GameObject _uiObject;
        private GameObject _hudObject;

        public AbstractGameState(Transform uiParent, GameObject uiPrefab, Transform hudParent = null)
        {
            _uiParent = uiParent;
            _uiPrefab = uiPrefab;
            _hudParent = hudParent;
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
