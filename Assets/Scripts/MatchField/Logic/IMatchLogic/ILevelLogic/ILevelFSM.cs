public interface ILevelFSM
{
    ILevelState CurrentState { get; set; }
    void ChangeState(ILevelState newState);
}
