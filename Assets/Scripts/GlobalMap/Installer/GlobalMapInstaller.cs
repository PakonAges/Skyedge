using UnityEngine;
using Zenject;

public class GlobalMapInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<GlobalMapViewModel>().AsSingle();
    }
}