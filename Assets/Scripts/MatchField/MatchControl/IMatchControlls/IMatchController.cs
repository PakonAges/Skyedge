using System.Threading.Tasks;

public interface IMatchController
{
    Task StartMatchAsync();
    void RestartMatch();
    void EndMatch();
}