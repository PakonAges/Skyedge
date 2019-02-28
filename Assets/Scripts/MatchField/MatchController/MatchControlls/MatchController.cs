using myUI;
using System;
using System.Threading.Tasks;
using Zenject;

/// <summary>
/// Passing commands to change Game Field State. Doesn't care about implementation details of modules
/// Generates Field, Reset Field, Spawns Hero
/// </summary>
public class MatchController : IMatchController, IInitializable, IDisposable
{

    readonly SignalBus _signalBus;
    readonly ICoreSceneController _coreSceneController;
    readonly IFieldVisualController _fieldVisual;
    readonly IFieldGenerator _fieldGenerator;
    readonly IMatchUIController _UIController;
    readonly IHeroSpawner _heroSpawner;
    readonly ILevelGenerator _levelGenerator;

    readonly ILevelController _levelController;
    readonly FieldGenerationRules _fieldGenerationRules;

    public MatchController( SignalBus signalBus,
                            ICoreSceneController coreSceneController,
                            IFieldVisualController fieldVisual,
                            IFieldGenerator fieldGenerator,
                            IFieldGenerationRulesProvider fieldDataProvider,
                            IHeroSpawner heroSpawner,
                            ILevelGenerator levelGenerator,
                            ILevelController levelController,
                            IMatchUIController myUIController)
    {
        _signalBus = signalBus;
        _coreSceneController = coreSceneController;
        _fieldVisual = fieldVisual;
        _fieldGenerator = fieldGenerator;
        _heroSpawner = heroSpawner;
        _levelGenerator = levelGenerator;
        _fieldGenerationRules = fieldDataProvider.GetGenerationRules();
        _levelController = levelController;
        _UIController = myUIController;
    }

    public void Initialize()
    {
        _signalBus.Subscribe<LevelRestartSignal>(async x => await RestartMatchAsync());
        _signalBus.Subscribe<ExitMatchSignal>(EndMatch);
    }

    public void Dispose()
    {
        _signalBus.TryUnsubscribe<LevelRestartSignal>(async x => await RestartMatchAsync());
        _signalBus.TryUnsubscribe<ExitMatchSignal>(EndMatch);
    }

    public async Task StartMatchAsync()
    {
        _fieldVisual.ShowBackGround();
        await GenerateAndShowFieldAsync();
        _levelGenerator.GenerateLevel(_fieldGenerationRules);
        await _UIController.ShowHUD();
        _levelController.StartMatch();
    }

    public async Task RestartMatchAsync()
    {
        _levelGenerator.ResetLevel(_fieldGenerationRules);
        await GenerateAndShowFieldAsync();
        _levelController.ResetLevel();
    }

    public void EndMatch()
    {
        _coreSceneController.SwitchScene(CoreScene.Map);
        _UIController.ClearUIStack();
    }

    async Task GenerateAndShowFieldAsync()
    {
        await _fieldGenerator.GenerateAndShowFieldAsync(_fieldGenerationRules);
        _heroSpawner.SpawnHero(_fieldGenerationRules.GetHeroSpawnPosition());
    }
}
