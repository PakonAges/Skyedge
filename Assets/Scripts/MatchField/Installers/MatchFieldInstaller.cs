using UnityEngine;
using Zenject;

public class MatchFieldInstaller : MonoInstaller
{
    public Camera MainCamera;

    [Header("Visualization refferences")]
    public GameObject BackGroundGO;
    public GameObject GridCell;
    public GameObject Chip;
    public FieldVisualizationParameters VisualizationParameters;

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
    }



    void InstallFieldVisualization()
    {
        Container.Bind<IFieldVisualization>().To<DefaultFieldVisualization>().AsSingle();
        Container.Bind<IChipPositionProvider>().To<ChipPositionProvider>().AsSingle();
        Container.Bind<IChipSizeProvider>().To<ChipSizeProvider>().AsSingle();
        Container.Bind<IChipPrefabProvider>().To<ChipPrefabProvider>().AsSingle();
        Container.Bind<IChipVisualProvider>().To<ChipVisualProvider>().AsSingle();
        Container.Bind<NormalChipCollection>().FromInstance(NormalChipsCollection).AsSingle();
        Container.Bind<ChipTypesCollection>().FromInstance(ItemCollection).AsSingle();
        Container.Bind<FieldVisualizationParameters>().FromInstance(VisualizationParameters).AsSingle();

        Container.Bind<IChipPainter>().To<ChipPainter>().AsSingle();
        Container.Bind<IChipMovement>().To<ChipMovement>().AsSingle();

        //ChipSpawner
        Container.Bind<IChipSpawner>().To<ChipSpawner>().AsSingle();
        Container.BindFactory<Chip, Chip.Factory>().FromComponentInNewPrefab(Chip);
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

    //void InstallNullObjects()
    //{
    //    Container.Bind<IFieldGenerationRules>().To<NullFieldGenerationRules>().WhenInjectedInto<FieldRulesProvider>();
    //}
}