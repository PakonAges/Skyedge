public class MatchFieldHUD : MyUiView
{
    public new UIViewType ViewType { get; private set; }
    readonly new IUiManager _uiManager;

    public MatchFieldHUD(IUiManager uIManager) : base(uIManager)
    {
        _uiManager = uIManager;
        ViewType = UIViewType.MatchFieldHUD;
    }


    public override void OnBackPressed()
    {
        //DO my stuff
    }

    public void OpenPauseMenu()
    {
        _uiManager.OpenWindowAsync(UIViewType.MatchPauseWindow);
    }
}