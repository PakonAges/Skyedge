using UnityEngine;
using Zenject;

public class MatchFieldInstaller : MonoInstaller
{
    public Camera MainCamera;

    [Header("Visualization references")]
    public GameObject BackGroundGO;
    public GameObject GridCell;
    public FieldVisualizationParameters VisualizationParameters;

    [Header("Chips references")]
    public GameObject ColorChip;
    public GameObject EmptyChip;
    public GameObject Hero;

    [Header("Assets Collection")]
    public ChipTypesCollection ChipsCollection;
    public ColorChipCollection ColorChipsCollection;

    [Header("Test Configs")]
    public SOFieldGenerationRules DebugFieldRules;

    public override void InstallBindings()
    {
        Container.Bind<Camera>().FromInstance(MainCamera);

        InputInstaller.Install(Container);
        MyUIInstaller.Install(Container);
        MatchFieldSignalsInstaller.Install(Container);

        InstallControllers();
        InstallFieldGeneration();
        InstalBackGroundSetup();
        InstallFieldVisualization();
        InstallChipFabrics();
        InstallFIeldLogic();
        InstallLevelLogic();
    }


    void InstallControllers()
    {
        Container.BindInterfacesAndSelfTo<MatchController>().AsSingle();
    }


    void InstallFieldGeneration()
    {
        Container.Bind<IFieldGenerator>().To<FieldGenerator>().AsSingle();
        Container.Bind<IFieldGenerationRulesProvider>().To<SOGenerationRulesProvider>().AsSingle(); //Debug only
        Container.Bind<SOFieldGenerationRules>().FromInstance(DebugFieldRules).AsSingle();
        Container.Bind<IChipInfoService>().To<ChipInfoService>().AsSingle();
        Container.Bind<IFieldDataProvider>().To<FieldDataProvider>().AsSingle();

    }



    void InstallFieldVisualization()
    {
        Container.BindInterfacesAndSelfTo<ChipPositionProvider>().AsSingle();
        Container.BindInterfacesAndSelfTo<FieldVisualController>().AsSingle();
        Container.Bind<IChipSizeProvider>().To<ChipSizeProvider>().AsSingle();
        Container.Bind<IChipPrefabProvider>().To<ChipPrefabProvider>().AsSingle();
        Container.Bind<IChipVisualProvider>().To<ChipVisualProvider>().AsSingle();
        Container.Bind<ColorChipCollection>().FromInstance(ColorChipsCollection).AsSingle();
        Container.Bind<ChipTypesCollection>().FromInstance(ChipsCollection).AsSingle();
        Container.Bind<FieldVisualizationParameters>().FromInstance(VisualizationParameters).AsSingle();

        Container.Bind<IChipPainter>().To<ChipPainter>().AsSingle();

    }

    void InstallChipFabrics()
    {
        Container.Bind<IChipManager>().To<ChipManager>().AsSingle();
        Container.Bind<IHeroSpawner>().To<HeroSpawner>().AsSingle();
        Container.BindFactory<ColorChip, ColorChip.Factory>().FromMonoPoolableMemoryPool<ColorChip>(x => x.WithInitialSize(64).FromComponentInNewPrefab(ColorChip));
        Container.BindFactory<EmptyChip, EmptyChip.Factory>().FromMonoPoolableMemoryPool<EmptyChip>(x => x.WithInitialSize(5).FromComponentInNewPrefab(EmptyChip));
        Container.BindFactory<HeroChip, HeroChip.Factory>().FromMonoPoolableMemoryPool<HeroChip>(x => x.WithInitialSize(1).FromComponentInNewPrefab(Hero));

    }

    void InstalBackGroundSetup()
    {
        //BackGround 
        //Container.Bind<IFieldBGSetup>().To<FieldBgSetup>().AsSingle();
        Container.BindInterfacesAndSelfTo<FieldBgSetup>().AsSingle();
        Container.Bind<IFieldBGScaleProvider>().To<BgScaleProvider>().AsSingle();
        Container.Bind<GameObject>().FromInstance(BackGroundGO).AsSingle();

        //Grid Generation
        Container.Bind<IFieldGridGenerator>().To<FieldGridGenerator>().AsSingle();
        Container.BindFactory<GridCell, GridCell.Factory>().FromComponentInNewPrefab(GridCell);
    }



    void InstallFIeldLogic()
    {
        Container.Bind<IChipMovement>().To<ChipMovement>().AsSingle();
        Container.Bind<IFieldFiller>().To<FieldFiller>().AsSingle();
        Container.Bind<IMatchChecker>().To<MatchChecker>().AsSingle();
        Container.Bind<IFieldCleaner>().To<FIeldCleaner>().AsSingle();
    }



    void InstallLevelLogic()
    {
        //Container.Bind<ILevelController>().To<LevelController>().AsSingle();
        Container.BindInterfacesAndSelfTo<LevelController>().AsSingle();
        Container.Bind<ILevelGenerator>().To<LevelGenerator>().AsSingle();
        Container.Bind<ILevelFSM>().To<LevelFSM>().AsSingle();
        Container.Bind<IPlayerController>().To<PlayerController>().AsSingle();
        Container.Bind<IEnemiesController>().To<EnemiesController>().AsSingle();
    }


    //void InstallNullObjects()
    //{
    //    Container.Bind<IFieldGenerationRules>().To<NullFieldGenerationRules>().WhenInjectedInto<FieldRulesProvider>();
    //}
}