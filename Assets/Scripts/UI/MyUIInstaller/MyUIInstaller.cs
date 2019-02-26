using Zenject;
using myUI;

public class MyUIInstaller : Installer<MyUIInstaller>
{
    public override void InstallBindings()
    {
        Container.Bind<IMyUIController>().To<MyUIController>().AsSingle();
        Container.Bind<IMyUIViewModelsStack>().To<MyUIViewModelsStack>().AsSingle();
        Container.Bind<IMyUIPrefabProvider>().To<MyUIAdressablePrefabProvider>().AsSingle();

        BindUIViewModels();
        BindGlobalMapViews();
    }

    void BindUIViewModels()
    {
        Container.BindInterfacesAndSelfTo<MatchHUDViewModel>().AsSingle();
        Container.BindInterfacesAndSelfTo<MatchPauseViewModel>().AsSingle();
        Container.BindInterfacesAndSelfTo<MatchEndViewModel>().AsSingle();
        Container.BindInterfacesAndSelfTo<ConfirmExitGameViewModel>().AsSingle();
    }

    void BindGlobalMapViews()
    {
        Container.BindInterfacesAndSelfTo<MapRegionModelView>().AsSingle();
    }
}