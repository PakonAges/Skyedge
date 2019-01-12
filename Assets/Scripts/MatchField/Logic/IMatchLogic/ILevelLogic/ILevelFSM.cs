public interface ILevelFSM
{
    MatchLevel Level { get; set; }
    ILevelState CurrentState { get; set; }
    void ChangeState(MatchLevelState newState);
}
