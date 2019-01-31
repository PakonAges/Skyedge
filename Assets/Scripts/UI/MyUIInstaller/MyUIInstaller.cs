using Zenject;
using myUI;

public class MyUIInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<IMyUIController>().To<MyUIController>().AsSingle();
        Container.Bind<IMyUIViewModelsStack>().To<MyUIViewModelsStack>().AsSingle();
        Container.Bind<IMyUIPrefabProvider>().To<MyUIAdressablePrefabProvider>().AsSingle();

        BindUIViewModels();

    }

    void BindUIViewModels()
    {
        Container.BindInterfacesAndSelfTo<MatchHUDViewModel>().AsSingle();
        Container.BindInterfacesAndSelfTo<MatchPauseViewModel>().AsSingle();
        Container.BindInterfacesAndSelfTo<MatchEndViewModel>().AsSingle();
        Container.BindInterfacesAndSelfTo<ConfirmExitGameViewModel>().AsSingle();
    }
}