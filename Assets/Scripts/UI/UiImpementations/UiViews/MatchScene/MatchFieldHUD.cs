public class MatchFieldHUD : MyUiView
{
    private override UIViewType _viewType { get; }

    public MatchFieldHUD(IUiManager uIManager) : base(uIManager)
    {
        _uiManager = uIManager;
    }


    public override void OnBackPressed()
    {
        //DO my stuff
    }
}