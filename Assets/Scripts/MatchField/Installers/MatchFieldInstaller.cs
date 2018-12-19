using UnityEngine;
using Zenject;

public class MatchFieldInstaller : MonoInstaller
{
    public Camera MainCamera;

    [Header("Visualization refferences")]
    public GameObject FieldVisualizatonSetup;
    public FieldVisualizationParameters VisualizationParameters;

    [Header("Assets Collection")]
    public ChipTypesCollection ItemCollection;
    public NormalChipCollection NormalChipsCollection;

    [Header("Test Configs")]
    public SOFieldGenerationRules DebugFieldRules;

    public override void InstallBindings()
    {
        Container.Bind<IFieldSceneController>().To<DefaultFieldSceneController>().WhenInjectedInto<HotKeyInput>();
        Container.Bind<IFieldGenerator>().To<FieldGenerator>().AsSingle();
        Container.Bind<IFieldGenerationRulesProvider>().To<SOGenerationRulesProvider>().AsSingle(); //Debug only
        Container.Bind<SOFieldGenerationRules>().FromInstance(DebugFieldRules).WhenInjectedInto<SOGenerationRulesProvider>();
        Container.Bind<IFieldVisualization>().To<DefaultFieldVisualization>().AsSingle();

        InstallVisualization();
    }
    private void InstallVisualization()
    {
        Container.Bind<IChipPositionProvider>().To<ChipWorldPositionProvider>().WhenInjectedInto<DefaultFieldVisualization>();
        Container.Bind<IChipPrefabProvider>().To<ChipPrefabProvider>().WhenInjectedInto<DefaultFieldVisualization>();
        Container.Bind<IChipVisualProvider>().To<ChipVisualProvider>().WhenInjectedInto<DefaultFieldVisualization>();
        Container.Bind<NormalChipCollection>().FromInstance(NormalChipsCollection).WhenInjectedInto<ChipVisualProvider>();
        Container.Bind<IChipSpawner>().To<ChipSpawner>().FromComponentOn(FieldVisualizatonSetup).WhenInjectedInto<DefaultFieldVisualization>();
        Container.Bind<ChipTypesCollection>().FromInstance(ItemCollection).WhenInjectedInto<ChipPrefabProvider>();
        Container.Bind<FieldVisualizationParameters>().FromInstance(VisualizationParameters).WhenInjectedInto<ChipWorldPositionProvider>();
        Container.Bind<FieldVisualizationParameters>().FromInstance(VisualizationParameters).WhenInjectedInto<DefaultFieldVisualization>();//Or use Singleton istead of WhenInjectedInto??

        //BG spawner
        Container.Bind<IFieldBGScaleProvider>().To<VerticalFieldBGScaleProvider>().WhenInjectedInto<DefaultFieldVisualization>();
        //Container.Bind<Sprite>().FromInstance(VisualizationParameters.DefaultFieldBG).WhenInjectedInto<FieldDataProvider>();
        Container.Bind<Camera>().FromInstance(MainCamera);
    }

    //void InstallNullObjects()
    //{
    //    Container.Bind<IFieldGenerationRules>().To<NullFieldGenerationRules>().WhenInjectedInto<FieldRulesProvider>();
    //}
}