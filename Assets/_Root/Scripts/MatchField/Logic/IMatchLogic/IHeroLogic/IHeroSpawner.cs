using UnityEngine;

public interface IHeroSpawner 
{
    IChip SpawnHero(Vector2Int SpawnPosition);
    void RemoveHero(HeroChip hero);
}
