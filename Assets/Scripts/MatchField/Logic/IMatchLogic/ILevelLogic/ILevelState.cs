public interface ILevelState
{
    MatchLevel Level { get; set; }
    void OnStateEnter();
    void OnStateExit();
}