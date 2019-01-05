using System.Threading.Tasks;

public class FieldFiller : IFieldFiller
{
    public Field GameField { get; set; }
    public FieldFillDirection FillDirection { get; set; }

    readonly IChipMovement _chipMovement;
    readonly IChipManager _chipManager;

    public FieldFiller( IChipMovement chipMovement,
                        IChipManager chipManager)
    {
        _chipMovement = chipMovement;
        _chipManager = chipManager;
    }

    public async Task FullFillAsync()
    {
        bool needFeelStep = await FillStepAsync();

        while (needFeelStep)
        {
            //fill untill all field filled
            needFeelStep = await FillStepAsync();
        }
    }

    async Task<bool> FillStepAsync()
    {
        bool movedChip = false;
        FillDirection = FieldFillDirection.RightToLeft; //Debuging!

        //Point to refactor sometime
        switch (FillDirection)
        {
            case FieldFillDirection.TopToBot:
            for (int y = GameField.Ysize - 2; y >= 0; y--)
            {
                for (int x = 0; x < GameField.Xsize; x++)
                {
                    Chip chip = GameField.FieldMatrix[x, y];

                    if (chip.IsMovable)
                    {
                        Chip chipBelow = GameField.FieldMatrix[x, y + 1];

                        if (chipBelow.ChipType == ChipType.EmptyCell)
                        {
                            _chipManager.RemoveChip(chipBelow);

                            await _chipMovement.MoveAsync(chip, x, y + 1);
                            GameField.FieldMatrix[x, y + 1] = chip;

                            GameField.FieldMatrix[x, y] = _chipManager.SpawnEmptyChip(x, y);
                            movedChip = true;
                        }
                    }
                }
            }

            //Check Top Row
            for (int x = 0; x < GameField.Xsize; x++)
            {
                Chip TopRowChip = GameField.FieldMatrix[x, 0];

                if (TopRowChip.ChipType == ChipType.EmptyCell)
                {
                    _chipManager.RemoveChip(TopRowChip);
                    var newChip = await _chipManager.SpawnRandomChip(x, -1);
                    await _chipMovement.MoveAsync(newChip, x, 0);
                    GameField.FieldMatrix[x, 0] = newChip;
                    movedChip = true;
                }
            }
            break;


            case FieldFillDirection.BotToTop:
            for (int y = 1; y < GameField.Ysize ; y++)
            {
                for (int x = 0; x < GameField.Xsize; x++)
                {
                    Chip chip = GameField.FieldMatrix[x, y];

                    if (chip.IsMovable)
                    {
                        Chip chipAbove = GameField.FieldMatrix[x, y - 1];

                        if (chipAbove.ChipType == ChipType.EmptyCell)
                        {
                            _chipManager.RemoveChip(chipAbove); //!

                            await _chipMovement.MoveAsync(chip, x, y - 1);
                            GameField.FieldMatrix[x, y - 1] = chip;

                            GameField.FieldMatrix[x, y] = _chipManager.SpawnEmptyChip(x, y);
                            movedChip = true;
                        }
                    }
                }
            }

            //Check Bot Row
            for (int x = 0; x < GameField.Xsize; x++)
            {
                Chip BotRowChip = GameField.FieldMatrix[x, GameField.Ysize - 1];

                if (BotRowChip.ChipType == ChipType.EmptyCell)
                {
                    _chipManager.RemoveChip(BotRowChip);
                    var newChip = await _chipManager.SpawnRandomChip(x, GameField.Ysize);
                    await _chipMovement.MoveAsync(newChip, x, GameField.Ysize - 1);
                    GameField.FieldMatrix[x, GameField.Ysize - 1] = newChip;
                    movedChip = true;
                }
            }
            break;


            case FieldFillDirection.LeftToRight:
            for (int x = GameField.Xsize - 2; x >= 0; x--)
            {
                for (int y = 0; y < GameField.Ysize; y++)
                {
                    Chip chip = GameField.FieldMatrix[x, y];

                    if (chip.IsMovable)
                    {
                        Chip chipToTheRight = GameField.FieldMatrix[x +1, y];

                        if (chipToTheRight.ChipType == ChipType.EmptyCell)
                        {
                            _chipManager.RemoveChip(chipToTheRight);

                            await _chipMovement.MoveAsync(chip, x + 1, y);
                            GameField.FieldMatrix[x + 1, y] = chip;

                            GameField.FieldMatrix[x, y] = _chipManager.SpawnEmptyChip(x, y);
                            movedChip = true;
                        }
                    }
                }
            }

            //Check Left Column
            for (int y = 0; y < GameField.Ysize; y++)
            {
                Chip LeftColumnChip = GameField.FieldMatrix[0, y];

                if (LeftColumnChip.ChipType == ChipType.EmptyCell)
                {
                    _chipManager.RemoveChip(LeftColumnChip);
                    var newChip = await _chipManager.SpawnRandomChip(-1, y);
                    await _chipMovement.MoveAsync(newChip, 0, y);
                    GameField.FieldMatrix[0, y] = newChip;
                    movedChip = true;
                }
            }
            break;



            case FieldFillDirection.RightToLeft:
            for (int x = 1; x < GameField.Xsize; x++)
            {
                for (int y = 0; y < GameField.Ysize; y++)
                {
                    Chip chip = GameField.FieldMatrix[x, y];

                    if (chip.IsMovable)
                    {
                        Chip chipToTheLeft = GameField.FieldMatrix[x - 1, y];

                        if (chipToTheLeft.ChipType == ChipType.EmptyCell)
                        {
                            _chipManager.RemoveChip(chipToTheLeft);

                            await _chipMovement.MoveAsync(chip, x - 1, y);
                            GameField.FieldMatrix[x - 1, y] = chip;

                            GameField.FieldMatrix[x, y] = _chipManager.SpawnEmptyChip(x, y);
                            movedChip = true;
                        }
                    }
                }
            }

            //Check Right Column
            for (int y = 0; y < GameField.Ysize; y++)
            {
                Chip RightColumnChip = GameField.FieldMatrix[GameField.Xsize - 1, y];

                if (RightColumnChip.ChipType == ChipType.EmptyCell)
                {
                    _chipManager.RemoveChip(RightColumnChip);
                    var newChip = await _chipManager.SpawnRandomChip(GameField.Xsize, y);
                    await _chipMovement.MoveAsync(newChip, GameField.Xsize - 1, y);
                    GameField.FieldMatrix[GameField.Xsize - 1, y] = newChip;
                    movedChip = true;
                }
            }
            break;

            default:
            break;
        }
        return movedChip;
    }
}