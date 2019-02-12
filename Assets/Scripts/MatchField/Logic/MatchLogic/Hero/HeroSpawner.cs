using System;
using UnityEngine;

public class HeroSpawner : IHeroSpawner
{
    readonly HeroChip.Factory _heroFactory;
    readonly IChipPositionProvider _chipPositioner;
    readonly IFieldDataProvider _fieldDataProvider;
    readonly IFieldCleaner _fieldCleaner;
    Field GameField { get { return _fieldDataProvider.GameField; } }
    HeroChip _hero;

    public HeroSpawner( HeroChip.Factory factory,
                        IChipPositionProvider chipPositionProvider,
                        IFieldDataProvider fieldDataProvider,
                        IFieldCleaner fieldCleaner)
    {
        _heroFactory = factory;
        _chipPositioner = chipPositionProvider;
        _fieldDataProvider = fieldDataProvider;
        _fieldCleaner = fieldCleaner;
    }


    public IChip SpawnHero(Vector2Int SpawnPosition)
    {
        //Just checking for errors
        if (SpawnPosition.x < 0 || SpawnPosition.y < 0 || SpawnPosition.x >= GameField.Xsize || SpawnPosition.y >= GameField.Ysize)
        {
            Debug.LogErrorFormat("Hero Position from Generation Rules is out of the Field. X = {0}, Y = {1}", SpawnPosition.x, SpawnPosition.y);
        }

        //In case we want to spawn Hero first
        if (GameField.FieldMatrix[SpawnPosition.x, SpawnPosition.y] != null)
        {
            _fieldCleaner.ClearChipAsync(SpawnPosition.x, SpawnPosition.y);
        }

        try
        {
            var newHero = _heroFactory.Create();
            newHero.name = "Hero";
            newHero.InitChip(ChipType.Hero, SpawnPosition.x, SpawnPosition.y, _chipPositioner.ChipSize, _chipPositioner.GetPosition(SpawnPosition.x, SpawnPosition.y));
            newHero.IsMovable = true;
            newHero.IsClearable = false;
            _hero = newHero;
            GameField.FieldMatrix[SpawnPosition.x, SpawnPosition.y] = newHero;
            return newHero;
        }
        catch (Exception e)
        {
            Debug.LogErrorFormat("AHTUNG: {0}", e);
            Debug.LogErrorFormat("Trying to spawn HERO at [{0}:{1}]", SpawnPosition.x, SpawnPosition.y);
        }
        return null;
    }

    public void RemoveHero(HeroChip hero)
    {
        hero.Dispose();
        _hero = null;
    }
}