using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ebac.StateMachine
{
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
            //Debug.Log(typeEnum);
        }

        public void SwitchStates(T state, params object[] objs)
        {
            if (_currentstate != null) _currentstate.OnStateExit();

            _currentstate = dicionaryStates[state];

            _currentstate.OnStateEnter(objs);
        }

        public void Update()
        {
            if (_currentstate != null) _currentstate.OnStateStay();
        }
    }
}
