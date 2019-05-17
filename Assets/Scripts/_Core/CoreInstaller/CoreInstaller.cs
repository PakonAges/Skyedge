using Zenject;
using myUI;

public class CoreInstaller : MonoInstaller
{
    public CoreScene SceneToLoad = CoreScene.Lobby;

    public override void InstallBindings()
    {
        Container.Bind<CoreScene>().FromInstance(SceneToLoad).AsSingle().WhenInjectedInto<CoreSceneController>();
        Container.BindInterfacesAndSelfTo<CoreSceneController>().AsSingle();

        //Global UI Setup
        Container.Bind<IMyUIViewModelsStack>().To<MyUIViewModelsStack>().AsSingle();
        Container.Bind<IMyUICoreController>().To<MyUICoreController>().AsSingle();
        Container.BindInterfacesAndSelfTo<MyUIAdressablePrefabProvider>().AsSingle();
        //Container.Bind<IMyUIPrefabProvider>().To<TestPrefabProvider>().AsSingle();
        Container.BindInterfacesAndSelfTo<ConfirmExitGameViewModel>().AsSingle();
    }
}