using Zenject;

public class MatchFieldInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<IFieldSceneController>().To<DefaultFieldSceneController>().WhenInjectedInto<HotKeyInput>();
        Container.Bind<IFieldGenerator>().To<FieldGenerator>().AsSingle();
        Container.Bind<IFieldDataProvider>().To<FieldDataProvider>().AsSingle();
        Container.Bind<IFieldVisualization>().To<DefaultFieldVisualization>().AsSingle();
    }

    //void InstallNullObjects()
    //{
    //    Container.Bind<IFieldGenerationRules>().To<NullFieldGenerationRules>().WhenInjectedInto<FieldRulesProvider>();
    //}
}