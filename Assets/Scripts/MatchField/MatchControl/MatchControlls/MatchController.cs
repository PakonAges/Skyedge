﻿using myUI;
using System.Threading.Tasks;
using UnityEngine;
using Zenject;

/// <summary>
/// Passing commands to change Game Field State. Doesn't care about implementation details of modules
/// Generates Field, Reset Field, Spawns Hero
/// </summary>
public class MatchController : IMatchController
{
    readonly IFieldVisualController _fieldVisual;
    readonly IFieldGenerator _fieldGenerator;
    readonly IFieldCleaner _fieldCleaner;
    readonly IHeroSpawner _heroSpawner;
    readonly ILevelGenerator _levelGenerator;
    readonly IPlayerController _playerController;
    readonly FieldGenerationRules _fieldGenerationRules;
    readonly ILevelController _levelController;
    readonly IMyUIController _UIController;

    public Field GameField;
    MatchLevel _matchLevel;

    public MatchController( IFieldVisualController fieldVisual,
                            IFieldGenerator fieldGenerator,
                            IFieldGenerationRulesProvider fieldDataProvider,
                            IFieldCleaner fieldCleaner,
                            IHeroSpawner heroSpawner,
                            IPlayerController playerController,
                            ILevelGenerator levelGenerator,
                            ILevelController levelController,
                            IMyUIController myUIController)
    {
        _fieldVisual = fieldVisual;
        _fieldGenerator = fieldGenerator;
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
        _fieldVisual.ShowBackGround();
        await GenerateFieldAsync();
    }

    public async Task RestartMatchAsync()
    {
        _fieldCleaner.ClearAllBoard();
        _levelGenerator.ResetLevel(_matchLevel, _fieldGenerationRules);
        await GenerateFieldAsync();
    }

    public void EndMatch()
    {

    }

    async Task GenerateFieldAsync()
    {
        GameField = await _fieldGenerator.GenerateFieldAsync(_fieldGenerationRules);
        SpawnHero();
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

        GenerateLevel();
    }

    async void GenerateLevel()
    {
        _matchLevel = _levelGenerator.GenerateLevel(_fieldGenerationRules);
        _levelController.InitLevel(_matchLevel);
        await _UIController.ShowHUD();
        _levelController.StartMatch();
    }
}
