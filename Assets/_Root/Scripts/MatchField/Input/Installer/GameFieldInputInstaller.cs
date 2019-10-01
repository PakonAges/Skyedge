using Zenject;

public class GameFieldInputInstaller : Installer<GameFieldInputInstaller>
{
    public override void InstallBindings()
    {
        Container.Bind<FieldGameplay.ITouchProcessor>().To<FieldGameplay.TouchInputProcessor>().AsSingle();
    }
}