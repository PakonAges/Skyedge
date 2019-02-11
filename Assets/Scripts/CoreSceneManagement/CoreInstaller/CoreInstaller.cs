using Zenject;

public class CoreInstaller : MonoInstaller
{
    public CoreScene SceneToLoad = CoreScene.MainMenu;

    public override void InstallBindings()
    {
        Container.Bind<CoreScene>().FromInstance(SceneToLoad).AsSingle().WhenInjectedInto<CoreSceneController>();
        Container.BindInterfacesAndSelfTo<CoreSceneController>().AsSingle();
    }
}