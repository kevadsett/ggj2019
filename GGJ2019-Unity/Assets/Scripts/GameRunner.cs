using UnityEngine;
using System.Collections;
using StateMachine;
using System.Collections.Generic;

public class GameRunner : MonoBehaviour
{
    public Transform GameCanvasTransform;

    public GameObject SplashUI;
    public GameObject RunningUI;
    public GameObject ReviewUI;

    private GameStateMachine _gameStateMachine;
    void Start()
    {
        var stateList = new Dictionary<EGameState, IGameState>
        {
            { EGameState.Splash, new SplashScreenState(GameCanvasTransform, SplashUI) },
        };

        _gameStateMachine = new GameStateMachine(stateList, EGameState.Splash);
    }

    void Update()
    {
        _gameStateMachine.Update(Time.deltaTime);
    }
}
