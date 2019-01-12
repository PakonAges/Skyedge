public enum ChipType
{
    ColorChip,
    EmptyChip,
    Hero,
    Enemy
}

public enum ChipColor
{
    Food,
    Crystal,
    Gold,
    Logs,
    Potion,
    Total
}

public enum FieldFillDirection
{
    TopToBot,
    BotToTop,
    LeftToRight,
    RightToLeft
}

public enum HeroSpawnOption
{
    Random,
    Concrete,
    RandomLeftSide,
    RandomRightSide,
    RandomTopSide,
    RandomBotSide
}

public enum MatchLevelType
{
    TurnsLimit
}

public enum MatchLevelState
{
    Unknown,
    LevelInit,
    PlayerMove,
    EnemyMove,
    LevelEnd,
    Pause
}