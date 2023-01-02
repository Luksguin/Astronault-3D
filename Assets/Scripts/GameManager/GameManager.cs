using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ebac.Core.Singleton;
using Ebac.StateMachine;

public class GameManager : Singleton<GameManager>
{
    public enum GameStates
    {
        INTRO,
        GAMEPLAY,
        PAUSE,
        WIN,
        LOSE
    }

    public StateMachine<GameStates> stateMachine;

    private void Start()
    {
        Init();
    }

    private void Init()
    {
        stateMachine = new StateMachine<GameStates>();

        stateMachine.Init();
        stateMachine.Register(GameStates.INTRO, new StateIntro());
        stateMachine.Register(GameStates.GAMEPLAY, new StateBase());
        stateMachine.Register(GameStates.PAUSE, new StateBase());
        stateMachine.Register(GameStates.WIN, new StateBase());
        stateMachine.Register(GameStates.LOSE, new StateBase());

        stateMachine.SwitchStates(GameStates.INTRO);
    }
}
