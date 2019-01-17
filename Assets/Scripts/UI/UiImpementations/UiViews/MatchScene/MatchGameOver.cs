public class MatchGameOver : MyUiView
{
    public new UIViewType ViewType { get; private set; }

    public MatchGameOver(IUiManager uIManager) : base(uIManager)
    {
        _uiManager = uIManager;
        ViewType = UIViewType.MatchGameOver;
    }
}
