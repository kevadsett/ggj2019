using UnityEngine;

namespace StateMachine
{
    public class SplashScreenState : AbstractGameState
    {
        public SplashScreenState(Transform uiParent, GameObject uiPrefab) : base(uiParent, uiPrefab)
        {

        }

        public override void Update(float dt)
        {
            if (Input.anyKey)
            {
                GameRunner.GameStateMachine.ChangeState(EGameState.Running);
            }
        }
    }
}
