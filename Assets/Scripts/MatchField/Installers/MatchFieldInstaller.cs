using System;
using UnityEngine;
using Zenject;

public class MatchFieldInstaller : MonoInstaller
{
    public GameObject FieldVisualizatonSetup;
    public FieldItemCollection ItemCollection;
    public FieldVisualizationParameters VisualizationParameters;

    public override void InstallBindings()
    {
        Container.Bind<IFieldSceneController>().To<DefaultFieldSceneController>().WhenInjectedInto<HotKeyInput>();
        Container.Bind<IFieldGenerator>().To<FieldGenerator>().AsSingle();
        Container.Bind<IFieldDataProvider>().To<FieldDataProvider>().AsSingle();
        Container.Bind<IFieldVisualization>().To<DefaultFieldVisualization>().AsSingle();

        InstallVisualization();
    }
    private void InstallVisualization()
    {
        Container.Bind<IFieldItemWorldPositionProvider>().To<FieldItemWorldPositionProvider>().WhenInjectedInto<DefaultFieldVisualization>();
        Container.Bind<IFieldItemVisualProvider>().To<FieldItemVisualProvider>().WhenInjectedInto<DefaultFieldVisualization>();
        Container.Bind<IFieldItemSpawner>().To<FieldItemSpawner>().FromComponentOn(FieldVisualizatonSetup).WhenInjectedInto<DefaultFieldVisualization>();
        Container.Bind<FieldItemCollection>().FromInstance(ItemCollection).WhenInjectedInto<FieldItemVisualProvider>();
        Container.Bind<FieldVisualizationParameters>().FromInstance(VisualizationParameters).WhenInjectedInto<FieldItemWorldPositionProvider>();
    }

    //void InstallNullObjects()
    //{
    //    Container.Bind<IFieldGenerationRules>().To<NullFieldGenerationRules>().WhenInjectedInto<FieldRulesProvider>();
    //}
}