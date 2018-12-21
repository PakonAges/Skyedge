using UnityEngine;
using Zenject;

public class MatchFieldInstaller : MonoInstaller
{
    public Camera MainCamera;

    [Header("Visualization refferences")]
    public GameObject BackGroundGO;
    public GameObject FieldVisualizatonSetup;
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
        Container.Bind<IFieldSceneController>().To<DefaultFieldSceneController>().WhenInjectedInto<HotKeyInput>();
    }



    void InstallFieldGeneration()
    {
        Container.Bind<IFieldGenerator>().To<FieldGenerator>().AsSingle();
        Container.Bind<IFieldGenerationRulesProvider>().To<SOGenerationRulesProvider>().AsSingle(); //Debug only
        Container.Bind<SOFieldGenerationRules>().FromInstance(DebugFieldRules).WhenInjectedInto<SOGenerationRulesProvider>();
    }



    void InstallFieldVisualization()
    {
        Container.Bind<IFieldVisualization>().To<DefaultFieldVisualization>().AsSingle();
        Container.Bind<IChipPositionProvider>().To<ChipWorldPositionProvider>().AsSingle();
        Container.Bind<IChipSpriteChanger>().To<ChipSpriteChanger>().WhenInjectedInto<DefaultFieldVisualization>();
        Container.Bind<IChipPrefabProvider>().To<ChipPrefabProvider>().WhenInjectedInto<DefaultFieldVisualization>();
        Container.Bind<IChipVisualProvider>().To<ChipVisualProvider>().WhenInjectedInto<DefaultFieldVisualization>();
        Container.Bind<NormalChipCollection>().FromInstance(NormalChipsCollection).WhenInjectedInto<ChipVisualProvider>();
        Container.Bind<IChipSpawner>().To<ChipSpawner>().FromComponentOn(FieldVisualizatonSetup).WhenInjectedInto<DefaultFieldVisualization>();
        Container.Bind<ChipTypesCollection>().FromInstance(ItemCollection).WhenInjectedInto<ChipPrefabProvider>();
        Container.Bind<FieldVisualizationParameters>().FromInstance(VisualizationParameters).AsSingle();
        Container.Bind<IChipMovement>().To<ChipMovement>().WhenInjectedInto<DefaultFieldVisualization>();

        //ChipSpawner
        //Container.BindFactory<Chip, Chip.Factory>();
    }



    void InstalBackGroundSetup()
    {
        Container.Bind<IFieldBGSetup>().To<FieldBgSetup>().AsSingle();
        Container.Bind<IFieldBGScaleProvider>().To<BgScaleProvider>().AsSingle();
        Container.Bind<GameObject>().FromInstance(BackGroundGO).WhenInjectedInto<FieldBgSetup>();
    }

    //void InstallNullObjects()
    //{
    //    Container.Bind<IFieldGenerationRules>().To<NullFieldGenerationRules>().WhenInjectedInto<FieldRulesProvider>();
    //}
}