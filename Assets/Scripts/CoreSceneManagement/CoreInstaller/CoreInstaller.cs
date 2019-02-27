using Zenject;

public class CoreInstaller : MonoInstaller
{
    public CoreScene SceneToLoad = CoreScene.Lobby;

    public override void InstallBindings()
    {
        Container.Bind<CoreScene>().FromInstance(SceneToLoad).AsSingle().WhenInjectedInto<CoreSceneController>();
        Container.BindInterfacesAndSelfTo<CoreSceneController>().AsSingle();
        MyUIInstaller.Install(Container);
    }
}