public interface ILevelFSM
{
    //MatchLevel Level { get; set; }
    ILevelState CurrentState { get; }
    void ChangeState(MatchLevelState newState);
    void SetupFSM(ILevelController levelController);
}
