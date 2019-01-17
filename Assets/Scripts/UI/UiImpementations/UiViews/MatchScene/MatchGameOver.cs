public class MatchGameOver : IUiView
{
    readonly IUiManager _uiManager;

    public MatchGameOver(IUiManager uIManager)
    {
        _uiManager = uIManager;
    }

    public void Open()
    {
        Open();
    }

    void Open()
    {
        //if not yet instantiated -> Instantiate
        //else Show?
    }

    public void Close()
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
