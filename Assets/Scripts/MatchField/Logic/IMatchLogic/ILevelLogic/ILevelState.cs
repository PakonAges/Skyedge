public interface ILevelState
{
    ILevelController LevelController { get; set; }
    void OnStateEnter();
    void OnStateExit();
}