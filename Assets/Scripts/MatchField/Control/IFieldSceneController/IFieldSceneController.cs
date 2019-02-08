using System.Threading.Tasks;

public interface IFieldSceneController
{
    Task StartMatchAsync();
    void ResetMatch();
}