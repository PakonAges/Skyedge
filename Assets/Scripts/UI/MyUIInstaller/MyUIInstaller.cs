using Zenject;
using myUI;

public class MyUIInstaller : Installer<MyUIInstaller>
{
    public override void InstallBindings()
    {
        Container.Bind<IMyUIViewModelsStack>().To<MyUIViewModelsStack>().AsSingle();
        Container.Bind<IMyUIPrefabProvider>().To<MyUIAdressablePrefabProvider>().AsSingle();
    }
}