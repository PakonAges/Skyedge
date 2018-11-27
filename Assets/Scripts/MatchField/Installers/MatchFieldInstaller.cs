using System;
using UnityEngine;
using Zenject;

public class MatchFieldInstaller : MonoInstaller
{
    public GameObject FieldVisualizatonSetup;

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
        Container.Bind<IFieldItemSpawner>().To<FieldItemSpawner>().WhenInjectedInto<DefaultFieldVisualization>();
    }

    //void InstallNullObjects()
    //{
    //    Container.Bind<IFieldGenerationRules>().To<NullFieldGenerationRules>().WhenInjectedInto<FieldRulesProvider>();
    //}
}