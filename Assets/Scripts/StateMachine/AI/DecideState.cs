using Zenject;

namespace Runner.StateMachine
{
    public class DecideState : IState
    {
        public void Enter()
        {
            //throw new System.NotImplementedException();
        }

        public void Exit()
        {
            //throw new System.NotImplementedException();
        }

        public CharacterState Tick()
        {
            UnityEngine.Debug.Log("Decided");
            return CharacterState.AIMoveState;
        }


    }
}
