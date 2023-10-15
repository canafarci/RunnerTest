using UnityEngine;
using Zenject;

namespace Runner.StateMachine
{
    public class AIWaitState : WaitState
    {
        //instance variables
        private int _timesWaitedBefore = 0;

        private AIWaitState()
        {
            _nextState = CharacterState.DecideState;
        }

        public override void Enter()
        {
            SetWaitDuration();
        }

        private void SetWaitDuration()
        {
            if (_timesWaitedBefore == 0)
            {
                float startWaitDuration = 3f;
                _timeLeft = startWaitDuration;
            }
            else
            {
                SetPseudoRandomWaitDuration();
            }
        }

        private void SetPseudoRandomWaitDuration()
        {
            float minRange = 2f - (_timesWaitedBefore / 5f);
            float maxRange = 4f - (_timesWaitedBefore / 5f);
            _timeLeft = Random.Range(minRange, maxRange);
        }

        protected override CharacterState OnTimerExpired()
        {
            _timesWaitedBefore++;
            return base.OnTimerExpired();
        }
    }
}
