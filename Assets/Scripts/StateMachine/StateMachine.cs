using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ebac.StateMachine
{
    public class Test
    {
        public enum EnumTeste
        {
            NONE
        }

        public void Aa()
        {
            StateMachine<EnumTeste> stateMachine = new StateMachine<EnumTeste>();

            stateMachine.Register(Test.EnumTeste.NONE, new StateBase());
        }
    }

    public class StateMachine<T> where T : System.Enum
    {
        public Dictionary<T, StateBase> dicionaryStates;
        private StateBase _currentstate;

        public StateBase CurrentState
        {
            get { return _currentstate; }
        }

        public void Init()
        {
            dicionaryStates = new Dictionary<T, StateBase>();
        }

        public void Register(T typeEnum, StateBase state)
        {
            dicionaryStates.Add(typeEnum, state);
        }

        public void SwitchStates(T state)
        {
            if (_currentstate != null) _currentstate.OnStateExit();

            _currentstate = dicionaryStates[state];

            _currentstate.OnStateEnter();
        }

        public void Update()
        {
            if (_currentstate != null) _currentstate.OnStateStay();
        }
    }

}
