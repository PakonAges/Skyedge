using System.Threading.Tasks;

public interface IMatchController
{
    Task StartMatchAsync();
    void ResetMatch();
}