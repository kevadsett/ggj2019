public interface IGameState
{
    void OnEnter();
    void Update(float dt);
    void OnExit();
}
