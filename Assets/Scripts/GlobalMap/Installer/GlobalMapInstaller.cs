using UnityEngine;
using Zenject;
using Cinemachine;
using GlobalMap;

public class GlobalMapInstaller : MonoInstaller
{
    public Camera MainCamera;
    public CinemachineVirtualCamera VirtualCamera;

    public override void InstallBindings()
    {
        InstalControllers();
        InstallInput();
        InstallUI();
    }

    void InstalControllers()
    {
        Container.Bind<IGlobalMapController>().To<GlobalMapController>().AsSingle();
    }

    void InstallInput()
    {
        Container.Bind<Camera>().FromInstance(MainCamera);
        Container.Bind<CinemachineVirtualCamera>().FromInstance(VirtualCamera);
        Container.Bind<ITouchProcessor>().To<TouchInputProcessor>().AsSingle();
    }

    void InstallUI()
    {
        Container.BindInterfacesAndSelfTo<MapRegionViewModel>().AsSingle();
        Container.Bind<GlobalMapViewModel>().AsSingle();
    }
}