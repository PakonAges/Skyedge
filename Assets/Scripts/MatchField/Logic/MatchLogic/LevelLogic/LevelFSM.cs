public class LevelFSM : ILevelFSM
{
    public ILevelState CurrentState { get; set; }

    public void ChangeState(ILevelState newState)
    {
        CurrentState.OnStateExit();
        CurrentState = newState;
        newState.OnStateEnter();
    }
}