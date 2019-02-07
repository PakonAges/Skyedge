using Zenject;

public class MatchFieldSignalsInstaller : Installer<MatchFieldSignalsInstaller>
{
    public override void InstallBindings()
    {
        SignalBusInstaller.Install(Container);
        Container.DeclareSignal<LevelRestartSignal>();
    }
}
