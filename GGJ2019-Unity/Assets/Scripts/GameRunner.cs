using UnityEngine;
using System.Collections;
using StateMachine;
using System.Collections.Generic;

public class GameRunner : MonoBehaviour
{
    public static GameStateMachine GameStateMachine;
    public GameSettings GameSettings;
    public Transform UICanvasTransform;
    public Transform GameCanvasTransform;

    public GameObject SplashUI;
    public GameObject RunningUI;
    public GameObject ReviewUI;

    void Start()
    {
        var stateList = new Dictionary<EGameState, IGameState>
        {
            { EGameState.Splash, new SplashScreenState(GameCanvasTransform, SplashUI) },
            { EGameState.Running, new RunningScreenState(GameCanvasTransform, RunningUI, UICanvasTransform, GameSettings.TenancyLength) },
            { EGameState.Review, new ReviewScreenState(GameCanvasTransform, ReviewUI) },
        };

        GameStateMachine = new GameStateMachine(stateList, EGameState.Splash);
    }

    void Update()
    {
        GameStateMachine.Update(Time.deltaTime);
    }
}
