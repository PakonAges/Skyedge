using myUI;
using System.Threading.Tasks;
using UnityEngine;
using Zenject;

/// <summary>
/// Passing commands to change Game Field State. Doesn't care about implementation details of modules
/// Generates Field, Reset Field, Spawns Hero
/// </summary>
public class MatchController : IMatchController
{
    readonly IFieldBGSetup _fieldBGSetup;
    readonly IFieldGenerator _fieldGenerator;
    readonly IFieldFiller _fieldFiller;
    readonly IChipMovement _chipMovement;
    readonly IMatchChecker _matchChecker;
    readonly IFieldCleaner _fieldCleaner;
    readonly IHeroSpawner _heroSpawner;
    readonly ILevelGenerator _levelGenerator;
    readonly IPlayerController _playerController;
    readonly FieldGenerationRules _fieldGenerationRules;
    readonly ILevelController _levelController;
    readonly IMyUIController _UIController;

    public Field GameField;
    MatchLevel _matchLevel;

    public MatchController( IFieldBGSetup fieldBGSetup,
                            IFieldGenerator fieldGenerator,
                            IFieldFiller fieldFiller,
                            IFieldGenerationRulesProvider fieldDataProvider,
                            IChipMovement chipMovement,
                            IMatchChecker matchChecker,
                            IFieldCleaner fieldCleaner,
                            IHeroSpawner heroSpawner,
                            IPlayerController playerController,
                            ILevelGenerator levelGenerator,
                            ILevelController levelController,
                            IMyUIController myUIController)
    {
        _fieldBGSetup = fieldBGSetup;
        _fieldGenerator = fieldGenerator;
        _fieldFiller = fieldFiller;
        _chipMovement = chipMovement;
        _matchChecker = matchChecker;
        _fieldCleaner = fieldCleaner;
        _heroSpawner = heroSpawner;
        _levelGenerator = levelGenerator;
        _playerController = playerController;
        _fieldGenerationRules = fieldDataProvider.GetGenerationRules();
        _levelController = levelController;
        _UIController = myUIController;
    }

    public async Task StartMatchAsync()
    {
        _fieldBGSetup.SetupBackGround();
        await GenerateFieldAsync();
        SpawnHero();
        GenerateLevel();
    }

    public void ResetMatch()
    {
        if (GameField != null)
        {
            _fieldCleaner.ClearAllBoard();
        }

        _levelGenerator.ResetLevel(_matchLevel, _fieldGenerationRules);
    }

    public void EndMatch()
    {

    }

    //GameField must be generated first. Because I send null object atm 
    async Task GenerateFieldAsync()
    {
        if (GameField != null)
        {
            ResetMatch();
        }
        else
        {
            //ShowBackGround();
        }

        GameField = await _fieldGenerator.GenerateFieldAsync(_fieldGenerationRules);
        _chipMovement.GameField = this.GameField;
        _matchChecker.GameField = this.GameField;
        _fieldCleaner.GameField = this.GameField;
        _fieldFiller.GameField = this.GameField;
    }

    void SpawnHero()
    {
        var Position = _fieldGenerationRules.GetHeroSpawnPosition();

        //Just checking for errors
        if (Position.x < 0 || Position.y < 0 || Position.x >= GameField.Xsize || Position.y >= GameField.Ysize)
        {
            Debug.LogErrorFormat("Hero Position from Generation Rules is out of the Field. X = {0}, Y = {1}",Position.x, Position.y);
        }

        //In case we want to spawn Hero first
        if (GameField.FieldMatrix[Position.x, Position.y] != null)
        {
            _fieldCleaner.ClearChipAsync(Position.x, Position.y);
        }

        GameField.FieldMatrix[Position.x, Position.y] = _heroSpawner.SpawnHero(Position.x, Position.y);
    }

    async void GenerateLevel()
    {
        _matchLevel = _levelGenerator.GenerateLevel(_fieldGenerationRules);
        _levelController.InitLevel(_matchLevel);
        await _UIController.ShowHUD();
        _levelController.StartMatch();
    }
}
