﻿using Zenject;
/// <summary>
/// Passing commands to change Global Field State. Doesn't care about implementation details of modules
/// </summary>
public class DefaultFieldSceneController : IFieldSceneController, IInitializable
{
    readonly IFieldBGSetup _fieldBGSetup;
    readonly IFieldGenerator _fieldGenerator;
    readonly IFieldFiller _fieldFiller;
    readonly IFieldVisualization _fieldVisualization;
    readonly IChipMovement _chipMovement;
    readonly IMatchChecker _matchChecker;
    readonly IFieldCleaner _fieldCleaner;
    readonly FieldGenerationRules _fieldGenerationRules;

    public Field GameField;

    public DefaultFieldSceneController( IFieldBGSetup fieldBGSetup,
                                        IFieldGenerator fieldGenerator,
                                        IFieldFiller fieldFiller,
                                        IFieldGenerationRulesProvider fieldDataProvider,
                                        IFieldVisualization fieldVisualization,
                                        IChipMovement chipMovement,
                                        IMatchChecker matchChecker,
                                        IFieldCleaner fieldCleaner)
    {
        _fieldBGSetup = fieldBGSetup;
        _fieldGenerator = fieldGenerator;
        _fieldFiller = fieldFiller;
        _fieldVisualization = fieldVisualization;
        _chipMovement = chipMovement;
        _matchChecker = matchChecker;
        _fieldCleaner = fieldCleaner;
        _fieldGenerationRules = fieldDataProvider.GetGenerationRules();

    }

    public void Initialize()
    {
        _fieldVisualization.SetupVisualization(_fieldGenerationRules.Xsize, _fieldGenerationRules.Ysize);
    }

    public void GenerateField()
    {
        ShowBackGround();
        GameField = _fieldGenerator.GenerateField(_fieldGenerationRules);
        _chipMovement.GameField = this.GameField;
        _matchChecker.GameField = this.GameField;
        _fieldCleaner.GameField = this.GameField;
        _fieldFiller.GameField = this.GameField;
        //_fieldFiller.FullFill();
    }

    public void ShowBackGround()
    {
        _fieldBGSetup.SetupBackGround(_fieldGenerationRules.BackgroundImage);
        _fieldVisualization.ShowEmptyGrid(_fieldGenerationRules.Xsize, _fieldGenerationRules.Ysize);
    }

    public void ResetField()
    {
        //Field.Reset();
        //_fieldVisualization.ResetField(Field.FieldData);
    }

    public void FindCombos()
    {
        _fieldCleaner.ClearAndRefillBoard();
    }
}
