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

    public GameObject PersistentObjects;
    public GameObject SplashUI;
    public GameObject RunningUI;
    public GameObject ReviewUI;

    public List<CharacterData> Characters;

    void Start()
    {
        var roomStatus = new RoomStatus();

        roomStatus.SetFloatValue(FloatRequirementType.Temperature, 0);
        roomStatus.SetFloatValue(FloatRequirementType.WaterLevel, 0);
        roomStatus.SetBoolValue(BooleanRequirementType.Light, true);

        StateData.Add("room", roomStatus);

        var stateList = new Dictionary<EGameState, IGameState>
        {
            { EGameState.Splash, new SplashScreenState(GameCanvasTransform, SplashUI) },
            { EGameState.Running, new RunningScreenState(
                GameCanvasTransform,
                RunningUI,
                UICanvasTransform,
                GameSettings,
                Characters
            ) },
            { EGameState.Review, new ReviewScreenState(GameCanvasTransform, ReviewUI) },
        };

        Instantiate(PersistentObjects, GameObject.Find("PersistentObjects").transform);

        GameStateMachine = new GameStateMachine(stateList, EGameState.Splash);
    }

    void Update()
    {
        GameStateMachine.Update(Time.deltaTime);
    }
}
