using System.Threading.Tasks;
using UnityEngine;
using Zenject;
/// <summary>
/// Passing commands to change Global Field State. Doesn't care about implementation details of modules
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
    readonly FieldGenerationRules _fieldGenerationRules;

    public Field GameField;

    public DefaultFieldSceneController( IFieldBGSetup fieldBGSetup,
                                        IFieldGenerator fieldGenerator,
                                        IFieldFiller fieldFiller,
                                        IFieldGenerationRulesProvider fieldDataProvider,
                                        IChipPositionProvider chipPositioner,
                                        IChipMovement chipMovement,
                                        IMatchChecker matchChecker,
                                        IFieldCleaner fieldCleaner,
                                        IHeroSpawner heroSpawner)
    {
        _fieldBGSetup = fieldBGSetup;
        _fieldGenerator = fieldGenerator;
        _fieldFiller = fieldFiller;
        _chipPositioner = chipPositioner;
        _chipMovement = chipMovement;
        _matchChecker = matchChecker;
        _fieldCleaner = fieldCleaner;
        _heroSpawner = heroSpawner;
        _fieldGenerationRules = fieldDataProvider.GetGenerationRules();

    }

    public void Initialize()
    {
        _chipPositioner.SetupChipParameters(_fieldGenerationRules.Xsize, _fieldGenerationRules.Ysize);
    }

    public async Task GenerateFieldAsync()
    {
        if (GameField != null)
        {
            ResetField();
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

        SpawnHero();
    }

    public void ShowBackGround()
    {
        _fieldBGSetup.SetupBackGround(_fieldGenerationRules.BackgroundImage);
        _fieldBGSetup.ShowEmptyGrid(_fieldGenerationRules.Xsize, _fieldGenerationRules.Ysize);
    }

    public void ResetField()
    {
        if (GameField != null)
        {
            _fieldCleaner.ClearAllBoard();
        }
    }

    public void FindCombos()
    {
        _fieldCleaner.ClearAndRefillBoard();
    }

    void SpawnHero()
    {
        var Position = _fieldGenerationRules.GetHeroSpawnPosition();

        //Just checking for errors
        if (Position.x < 0 || Position.y < 0 || Position.x >= GameField.Xsize || Position.y >= GameField.Ysize)
        {
            Debug.LogErrorFormat("Hero Position from Generation Rules is out of the Field. X = {0}, Y = {1}",Position.x, Position.y);
        }

        _fieldCleaner.ClearChipAsync(Position.x, Position.y);
        GameField.FieldMatrix[Position.x, Position.y] = _heroSpawner.SpawnHero(Position.x, Position.y);
    }
}
