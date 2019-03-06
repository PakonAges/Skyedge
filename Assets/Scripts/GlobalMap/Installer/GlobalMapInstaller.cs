using UnityEngine;
using Zenject;
using Cinemachine;
using GlobalMap;

public class GlobalMapInstaller : MonoInstaller
{
    public Camera MainCamera;
    public CinemachineVirtualCamera VirtualCamera;
    public GameObject HeroPrefab;

    public override void InstallBindings()
    {
        InstalControllers();
        InstalLogic();
        InstalInput();
        InstalUI();
    }

    void InstalControllers()
    {
        Container.Bind<IGlobalMapController>().To<GlobalMapController>().AsSingle();
    }

    void InstalLogic()
    {
        Container.BindFactory<IGlobalMapHero, GlobalMapHeroFactory>().FromComponentInNewPrefab(HeroPrefab);
        Container.Bind<IGlobalMapHeroSpawner>().To<GlobalMapHeroSpawner>().AsSingle();
    }

    void InstalInput()
    {
        Container.Bind<Camera>().FromInstance(MainCamera);
        Container.Bind<CinemachineVirtualCamera>().FromInstance(VirtualCamera);
        Container.Bind<ITouchProcessor>().To<TouchInputProcessor>().AsSingle();
    }

    void InstalUI()
    {
        Container.Bind<IGlobalMapUIController>().To<GlobalMapUIContoller>().AsSingle();
        Container.BindInterfacesAndSelfTo<MapRegionViewModel>().AsSingle();
        Container.Bind<GlobalMapHUDViewModel>().AsSingle();
    }
}