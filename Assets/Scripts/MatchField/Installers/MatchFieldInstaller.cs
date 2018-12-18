﻿using System;
using UnityEngine;
using Zenject;

public class MatchFieldInstaller : MonoInstaller
{
    public GameObject FieldVisualizatonSetup;
    public ChipTypesCollection ItemCollection;
    public NormalChipCollection NormalChipsCollection;
    public FieldVisualizationParameters VisualizationParameters;
    public SOFieldGenerationRules DebugFieldRules;
    public Camera MainCamera;

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