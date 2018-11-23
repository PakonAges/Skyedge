using Zenject;

public class MatchFieldInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        InstallNullObjects();

        Container.Bind<IFieldSceneController>().To<FieldSceneController>().WhenInjectedInto<HotKeyInput>();
        Container.Bind<IFieldGenerator>().To<FieldGenerator>().AsSingle();
        Container.Bind<IFieldGenerationRulesProvider>().To<FieldRulesProvider>().AsSingle();
        Container.Bind<IFieldVisualization>().To<FieldVisualization>().AsSingle();
    }

    void InstallNullObjects()
    {
        Container.Bind<IFieldGenerationRules>().To<NullFieldGenerationRules>().WhenInjectedInto<FieldRulesProvider>();
    }
}