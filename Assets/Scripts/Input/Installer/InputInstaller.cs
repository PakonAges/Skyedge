using Zenject;

public class InputInstaller : Installer<InputInstaller>
{
    public override void InstallBindings()
    {
        Container.Bind<ITouchProcessor>().To<TouchInputProcessor>().AsSingle();
    }
}
