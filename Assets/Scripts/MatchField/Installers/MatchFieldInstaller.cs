using UnityEngine;
using Zenject;

public class MatchFieldInstaller : MonoInstaller
{
    public Camera MainCamera;

    [Header("Visualization references")]
    public GameObject BackGroundGO;
    public GameObject GridCell;
    //public GameObject Chip;
    public FieldVisualizationParameters VisualizationParameters;

    [Header("Chips references")]
    public GameObject ColorChip;
    public GameObject EmptyChip;

    [Header("Assets Collection")]
    public ChipTypesCollection ItemCollection;
    public NormalChipCollection NormalChipsCollection;

    [Header("Test Configs")]
    public SOFieldGenerationRules DebugFieldRules;

    public override void InstallBindings()
    {
        Container.Bind<Camera>().FromInstance(MainCamera);

        InstallControllers();
        InstallFieldGeneration();
        InstalBackGroundSetup();
        InstallFieldVisualization();
        InstallChipFabrics();
        InstallFIeldLogic();
    }



    void InstallControllers()
    {
        Container.BindInterfacesAndSelfTo<DefaultFieldSceneController>().AsSingle();
    }



    void InstallFieldGeneration()
    {
        Container.Bind<IFieldGenerator>().To<FieldGenerator>().AsSingle();
        Container.Bind<IFieldGenerationRulesProvider>().To<SOGenerationRulesProvider>().AsSingle(); //Debug only
        Container.Bind<SOFieldGenerationRules>().FromInstance(DebugFieldRules).AsSingle();
        Container.Bind<IChipInfoService>().To<ChipInfoService>().AsSingle();
    }



    void InstallFieldVisualization()
    {
        Container.Bind<IChipPositionProvider>().To<ChipPositionProvider>().AsSingle();
        Container.Bind<IChipSizeProvider>().To<ChipSizeProvider>().AsSingle();
        Container.Bind<IChipPrefabProvider>().To<ChipPrefabProvider>().AsSingle();
        Container.Bind<IChipVisualProvider>().To<ChipVisualProvider>().AsSingle();
        Container.Bind<NormalChipCollection>().FromInstance(NormalChipsCollection).AsSingle();
        Container.Bind<ChipTypesCollection>().FromInstance(ItemCollection).AsSingle();
        Container.Bind<FieldVisualizationParameters>().FromInstance(VisualizationParameters).AsSingle();

        Container.Bind<IChipPainter>().To<ChipPainter>().AsSingle();
        Container.Bind<IChipMovement>().To<ChipMovement>().AsSingle();

    }

    void InstallChipFabrics()
    {
        //ChipSpawner
        Container.Bind<IChipManager>().To<ChipManager>().AsSingle();
        //Container.BindFactory<Chip, Chip.Factory>().FromMonoPoolableMemoryPool<Chip>(x => x.WithInitialSize(64).FromComponentInNewPrefab(Chip));
        Container.BindFactory<ColorChip, ColorChip.Factory>().FromMonoPoolableMemoryPool<ColorChip>(x => x.WithInitialSize(64).FromComponentInNewPrefab(ColorChip));
        Container.BindFactory<EmptyChip, EmptyChip.Factory>().FromMonoPoolableMemoryPool<EmptyChip>(x => x.WithInitialSize(16).FromComponentInNewPrefab(EmptyChip));

    }

    void InstalBackGroundSetup()
    {
        //BackGround 
        Container.Bind<IFieldBGSetup>().To<FieldBgSetup>().AsSingle();
        Container.Bind<IFieldBGScaleProvider>().To<BgScaleProvider>().AsSingle();
        Container.Bind<GameObject>().FromInstance(BackGroundGO).AsSingle();

        //Grid Generation
        Container.Bind<IFieldGridGenerator>().To<FieldGridGenerator>().AsSingle();
        Container.BindFactory<GridCell, GridCell.Factory>().FromComponentInNewPrefab(GridCell);
    }



    void InstallFIeldLogic()
    {
        Container.Bind<IFieldFiller>().To<FieldFiller>().AsSingle();
        Container.Bind<IMatchChecker>().To<MatchChecker>().AsSingle();
        Container.Bind<IFieldCleaner>().To<FIeldCleaner>().AsSingle();
    }

    //void InstallNullObjects()
    //{
    //    Container.Bind<IFieldGenerationRules>().To<NullFieldGenerationRules>().WhenInjectedInto<FieldRulesProvider>();
    //}
}