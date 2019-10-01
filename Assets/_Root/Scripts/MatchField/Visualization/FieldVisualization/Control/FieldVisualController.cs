using Zenject;

public class FieldVisualController : IFieldVisualController
{
    readonly IFieldBGSetup _fieldBG;

    public FieldVisualController(IFieldBGSetup fieldBG)
    {
        _fieldBG = fieldBG;
    }

    public void ShowBackGround()
    {
        _fieldBG.SetupBackGround();
    }
}
