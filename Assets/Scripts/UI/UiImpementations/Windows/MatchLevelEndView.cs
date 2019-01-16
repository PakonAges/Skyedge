public class MatchLevelEndView : IWindow
{
    readonly IUiManager _uiManager;

    public MatchLevelEndView(IUiManager uIManager)
    {
        _uiManager = uIManager;
    }

    public void Show()
    {
        Open();
    }

    void Open()
    {
        //if not yet instantiated -> Instantiate
        //else Show?
    }

    public void Hide()
    {
        //Set Active = false
        //Or Destroy?
    }

    public void OnBackPressed()
    {
        _uiManager.CloseTopWindow(); //Are we sure that top window is this window? or should we use Close(this)?

        //Or Quit game
        //Or show another window?
    }
}
