public class FieldFiller : IFieldFiller
{
    public Field GameField { get; set; }
    public FieldFillDirection FillDirection { get; set; }

    readonly IChipMovement _chipMovement;
    readonly IChipSpawner _chipSpawner;

    public FieldFiller( IChipMovement chipMovement,
                        IChipSpawner chipSpawner)
    {
        _chipMovement = chipMovement;
        _chipSpawner = chipSpawner;
    }

    public bool FillStep()
    {
        bool movedChip = false;
        //deBug
        FillDirection = FieldFillDirection.TopToBot;

        //Point to refactor sometime
        switch (FillDirection)
        {
            case FieldFillDirection.TopToBot:
            for (int y = GameField.Ysize - 2; y >= 0; y--)
            {
                for (int x = 0; x < GameField.Xsize; x++)
                {
                    Chip chip = GameField.FieldMatrix[x, y];

                    if (chip.IsMoveable)
                    {
                        Chip chipBelow = GameField.FieldMatrix[x, y + 1];

                        if (chipBelow.ChipType == ChipType.EmptyCell)
                        {
                            _chipMovement.Move(chip, x, y + 1);
                            GameField.FieldMatrix[x, y + 1] = chip;
                            GameField.FieldMatrix[x, y] = _chipSpawner.SpawnChip(ChipType.EmptyCell, x, y);
                            movedChip = true;
                        }
                    }
                }
            }

            //Check Top Row
            for (int x = 0; x < GameField.Xsize; x++)
            {
                Chip chipBelow = GameField.FieldMatrix[x, 0];

                if (chipBelow.ChipType == ChipType.EmptyCell)
                {
                    var newChip = _chipSpawner.SpawnChip(ChipType.NormalChip, x, 0);
                    GameField.FieldMatrix[x, 0] = newChip;
                    movedChip = true;
                }
            }

            break;

            case FieldFillDirection.BotToTop:
            break;

            case FieldFillDirection.LeftToRight:
            break;

            case FieldFillDirection.RightToLeft:
            break;

            default:
            break;
        }

        return movedChip;
    }

    public void FullFill(Field field)
    {
        GameField = field;

        while (FillStep())
        {
            //fill untill all field filled
        }
    }
}