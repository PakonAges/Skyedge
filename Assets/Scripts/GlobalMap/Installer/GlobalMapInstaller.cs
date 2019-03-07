using UnityEngine;
using Zenject;
using Cinemachine;
using GlobalMap;

public class GlobalMapInstaller : MonoInstaller
{
    public Camera MainCamera;
    public CinemachineVirtualCamera VirtualCamera;
    public GameObject HeroPrefab;
    public SOGlobalMapPersistantData PersistanceMock;

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
        Container.BindFactory<GlobalMap.IHero, HeroFactory>().FromComponentInNewPrefab(HeroPrefab);
        Container.Bind<GlobalMap.IHeroSpawner>().To<GlobalMap.HeroSpawner>().AsSingle();
        Container.Bind<IPersistentDataProvider>().To<PersistentDataProvider>().AsSingle();
        Container.Bind<SOGlobalMapPersistantData>().FromInstance(PersistanceMock);
        Container.Bind<ICameraController>().To<CameraController>().AsSingle();
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