using System.Threading.Tasks;
/// <summary>
/// Passes commands to restart level, update/show UI etc.
/// </summary>
public interface ILevelController
{
    MatchLevel CurrentLevel { get; }
    void StartMatch();
    void ResetLevel();
    Task EndOfPlayerMoveAsync();
}
