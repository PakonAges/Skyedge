public class MatchPauseWindow : MyUiView
{
    public new UIViewType ViewType { get; private set; }

    public MatchPauseWindow(IUiManager uIManager) : base(uIManager)
    {
        _uiManager = uIManager;
        ViewType = UIViewType.MatchPauseWindow;
    }
}
