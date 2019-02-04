/// <summary>
/// Passes commands to restart level, update/show UI etc.
/// </summary>
public interface ILevelController
{
    MatchLevel CurrentLevel { get; }

    void InitLevel(MatchLevel level);
    void StartMatch();
    void ResetLevel();
    void EndOfPlayerMove();
}
