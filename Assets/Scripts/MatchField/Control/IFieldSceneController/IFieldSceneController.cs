using System.Threading.Tasks;

public interface IFieldSceneController
{
    Task GenerateFieldAsync();
    void ResetField();
    void FindCombos();//debug?
}
