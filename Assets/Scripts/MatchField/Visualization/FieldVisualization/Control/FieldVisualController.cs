using Zenject;

public class FieldVisualController : IFieldVisualController, IInitializable
{
    readonly IFieldBGSetup _fieldBG;

    public FieldVisualController(IFieldBGSetup fieldBG)
    {
        _fieldBG = fieldBG;
    }

    public void Initialize()
    {
        
    }

    public void ShowBackGround()
    {
        _fieldBG.SetupBackGround();
    }

    public void ShowChips()
    {
        
    }
}
