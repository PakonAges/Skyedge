using System.Threading.Tasks;

public interface IFieldSceneController
{
    Task StartMatchAsync();
    //Task GenerateFieldAsync();
    void ResetMatch();
    //void FindCombos();//debug?
}
