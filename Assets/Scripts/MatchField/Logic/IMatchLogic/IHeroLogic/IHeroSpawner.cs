public interface IHeroSpawner 
{
    IChip SpawnHero(int Xpos, int Ypos);
    void RemoveHero(Hero hero);
}
