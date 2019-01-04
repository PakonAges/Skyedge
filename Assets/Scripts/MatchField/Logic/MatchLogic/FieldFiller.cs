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

    public async void FullFill()
    {
        await FullFillAsync();
    }

    async Task FullFillAsync()
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
        FillDirection = FieldFillDirection.TopToBot; //Debuging!

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
                            //await _chipMovement.Swap(chip, chipBelow);
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
                    var newChip = await _chipManager.SpawnRandomChip(x, 0);
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
}