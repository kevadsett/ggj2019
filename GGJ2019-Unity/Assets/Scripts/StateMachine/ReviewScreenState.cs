using UnityEngine;

namespace StateMachine
{
    public class ReviewScreenState : AbstractGameState
    {
        public ReviewScreenState(Transform uiParent, GameObject uiPrefab) : base(uiParent, uiPrefab)
        {

        }

        public override void Update(float dt)
        {
            if (Input.anyKey)
            {
                GameRunner.GameStateMachine.ChangeState(EGameState.Splash);
            }
        }
    }
}
