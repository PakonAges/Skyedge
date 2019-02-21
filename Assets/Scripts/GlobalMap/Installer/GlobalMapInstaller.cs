using UnityEngine;
using Zenject;
using GlobalMap;
using Cinemachine;

public class GlobalMapInstaller : MonoInstaller
{
    public Camera MainCamera;
    public CinemachineVirtualCamera VirtualCamera;

    public override void InstallBindings()
    {
        InstallInput();
        Container.Bind<GlobalMapViewModel>().AsSingle();
    }

    void InstallInput()
    {
        Container.Bind<Camera>().FromInstance(MainCamera);
        Container.Bind<CinemachineVirtualCamera>().FromInstance(VirtualCamera);

        Container.Bind<GlobalMap.ITouchProcessor>().To<GlobalMap.TouchInputProcessor>().AsSingle();
    }
}