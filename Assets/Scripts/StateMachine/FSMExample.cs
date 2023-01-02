using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FSMExample : MonoBehaviour
{
    public enum EnumExemple
    {
        STATE_ONE,
        STATE_TWO,
        STATE_THREE
    }

    public StateMachine<EnumExemple> stateMachine;

    private void Start()
    {
        stateMachine = new StateMachine<EnumExemple>();

        stateMachine.Init();
        stateMachine.Register(EnumExemple.STATE_ONE, new StateBase());
        stateMachine.Register(EnumExemple.STATE_TWO, new StateBase());
        stateMachine.Register(EnumExemple.STATE_THREE, new StateBase());
    }
}
