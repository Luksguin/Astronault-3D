using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    public enum States
    {
        IDLE
    }

    private StateBase _currentstate;
    public static StateMachine Instance;

    public Dictionary<States, StateBase> dicionaryStates;

    private void Awake()
    {
        Instance = this;

        dicionaryStates = new Dictionary<States, StateBase>();
        dicionaryStates.Add(States.IDLE, new StateBase());

        SwitchStates(States.IDLE);
    }

    public void SwitchStates(States state)
    {
        if (_currentstate != null) _currentstate.OnStateExit();

        _currentstate = dicionaryStates[state];

        if (_currentstate != null) _currentstate.OnStateEnter();
    }

    private void Update()
    {
        if (_currentstate != null) _currentstate.OnStateStay();
    }
}
