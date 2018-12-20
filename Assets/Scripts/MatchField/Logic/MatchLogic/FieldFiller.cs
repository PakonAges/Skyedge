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
                        Chip prevChip = GameField.FieldMatrix[x, y + 1];

                        if (prevChip.ChipType == ChipType.EmptyCell)
                        {
                            _chipMovement.Move(chip, x, y + 1);
                            GameField.FieldMatrix[x, y + 1] = chip;
                            //_chipSpawner.SpawnChip(ChipType.EmptyCell, x, y);
                            movedChip = true;
                        }
                    }
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

    public void FullFill()
    {
        while (FillStep())
        {
            //fill untill all field filled
        }
    }
}