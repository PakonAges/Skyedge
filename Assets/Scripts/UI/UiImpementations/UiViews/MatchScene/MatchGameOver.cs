public class MatchGameOver : MyUiView
{
    public new UIViewType ViewType { get; private set; }

    public override void Construct(IUiManager uIManager)
    {
        base.Construct(uIManager);
        ViewType = UIViewType.MatchGameOver;
    }
}
