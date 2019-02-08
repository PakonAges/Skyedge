using UnityEngine;
using Zenject;

public class CoreMenuInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<CoreMenuViewModel>().AsSingle();
    }
}