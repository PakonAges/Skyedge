using UnityEngine;
using Zenject;

public class UiInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<IUiManager>().To<MatchSceneUiManager>().AsSingle();
        Container.Bind<IUiPrefabProvider>().To<UiPrefabProvider>().AsSingle();
    }
}