using System.Threading.Tasks;
using UnityEngine;
using Zenject;
/// <summary>
/// Passing commands to change Game Field State. Doesn't care about implementation details of modules
/// Generates Field, Reset Field, Spawns Hero
/// </summary>
public class DefaultFieldSceneController : IFieldSceneController, IInitializable
{
    readonly IFieldBGSetup _fieldBGSetup;
    readonly IFieldGenerator _fieldGenerator;
    readonly IFieldFiller _fieldFiller;
    readonly IChipPositionProvider _chipPositioner;
    readonly IChipMovement _chipMovement;
    readonly IMatchChecker _matchChecker;
    readonly IFieldCleaner _fieldCleaner;
    readonly IHeroSpawner _heroSpawner;
    readonly ILevelGenerator _levelGenerator;
    readonly ILevelFSM _levelFSM;
    readonly FieldGenerationRules _fieldGenerationRules;

    public Field GameField;
    MatchLevel _matchLevel;

    public DefaultFieldSceneController( IFieldBGSetup fieldBGSetup,
                                        IFieldGenerator fieldGenerator,
                                        IFieldFiller fieldFiller,
                                        IFieldGenerationRulesProvider fieldDataProvider,
                                        IChipPositionProvider chipPositioner,
                                        IChipMovement chipMovement,
                                        IMatchChecker matchChecker,
                                        IFieldCleaner fieldCleaner,
                                        IHeroSpawner heroSpawner,
                                        ILevelFSM levelFSM,
                                        ILevelGenerator levelGenerator)
    {
        _fieldBGSetup = fieldBGSetup;
        _fieldGenerator = fieldGenerator;
        _fieldFiller = fieldFiller;
        _chipPositioner = chipPositioner;
        _chipMovement = chipMovement;
        _matchChecker = matchChecker;
        _fieldCleaner = fieldCleaner;
        _heroSpawner = heroSpawner;
        _levelGenerator = levelGenerator;
        _levelFSM = levelFSM;
        _fieldGenerationRules = fieldDataProvider.GetGenerationRules();

    }

    public void Initialize()
    {
        _chipPositioner.SetupChipParameters(_fieldGenerationRules.Xsize, _fieldGenerationRules.Ysize);

    }

    public async Task StartMatchAsync()
    {
        //_levelFSM.CurrentState = LevelInitState... hm? Where to get this state refference? Or should it be in FSM?
        //OR! should it be all in MatchLevel Class? Yes!
        await GenerateFieldAsync();

        GenerateLevel();
        SpawnHero();
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
            ShowBackGround();
        }

        GameField = await _fieldGenerator.GenerateFieldAsync(_fieldGenerationRules);
        _chipMovement.GameField = this.GameField;
        _matchChecker.GameField = this.GameField;
        _fieldCleaner.GameField = this.GameField;
        _fieldFiller.GameField = this.GameField;
    }

    void ShowBackGround()
    {
        _fieldBGSetup.SetupBackGround(_fieldGenerationRules.BackgroundImage);
        _fieldBGSetup.ShowEmptyGrid(_fieldGenerationRules.Xsize, _fieldGenerationRules.Ysize);
    }

    public void ResetMatch()
    {
        if (GameField != null)
        {
            _fieldCleaner.ClearAllBoard();
        }

        _levelGenerator.ResetLevel(_matchLevel, _fieldGenerationRules);
    }

    //public void FindCombos() //Debug
    //{
    //    _fieldCleaner.ClearAndRefillBoard();
    //}

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

    void GenerateLevel()
    {
        _matchLevel = _levelGenerator.GenerateLevel(_fieldGenerationRules);
    }
}
