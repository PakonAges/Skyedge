using System.Threading.Tasks;

public interface IMatchController
{
    Task StartMatchAsync();
    Task RestartMatchAsync();
    void EndMatch();
}