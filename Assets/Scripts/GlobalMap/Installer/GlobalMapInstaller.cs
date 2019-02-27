using UnityEngine;
using Zenject;
using Cinemachine;

public class GlobalMapInstaller : MonoInstaller
{
    public Camera MainCamera;
    public CinemachineVirtualCamera VirtualCamera;

    public override void InstallBindings()
    {
        InstallInput();
        InstallUI();
    }

    void InstallInput()
    {
        Container.Bind<Camera>().FromInstance(MainCamera);
        Container.Bind<CinemachineVirtualCamera>().FromInstance(VirtualCamera);
        Container.Bind<GlobalMap.ITouchProcessor>().To<GlobalMap.TouchInputProcessor>().AsSingle();
    }

    void InstallUI()
    {
        Container.BindInterfacesAndSelfTo<MapRegionViewModel>().AsSingle();
        Container.Bind<GlobalMapViewModel>().AsSingle();
    }
}