using Zenject;

public class MatchFieldInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<IFieldSceneController>().To<FieldSceneController>().AsSingle();
        Container.Bind<IFieldGenerator>().To<FieldGenerator>().AsSingle();
        Container.Bind<IFieldGenerationRulesProvider>().To<deBugFieldRulesProvider>().AsSingle();
        Container.Bind<IFieldVisualization>().To<FieldVisualization>().AsSingle();
    }
}