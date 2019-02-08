using Zenject;

public class CoreInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        //Container.Bind<ICoreSceneController>().To<CoreSceneController>().AsSingle();
        Container.BindInterfacesAndSelfTo<CoreSceneController>().AsSingle();
    }
}