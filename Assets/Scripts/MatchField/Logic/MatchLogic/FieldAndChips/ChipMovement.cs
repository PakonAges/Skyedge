using DG.Tweening;
using System.Threading.Tasks;
using UnityEngine;

public class ChipMovement : IChipMovement
{
    readonly IChipPositionProvider _chipPositionProvider;
    readonly IFieldDataProvider _fieldDataProvider;
    readonly float _movementDuration;
    readonly float _swapDuration;
    Field GameField { get { return _fieldDataProvider.GameField; } }

    public ChipMovement(    IChipPositionProvider chipPositionProvider,
                            IFieldDataProvider fieldDataProvider,
                            FieldVisualizationParameters fieldVisualizationParameters)
    {
        _chipPositionProvider = chipPositionProvider;
        _fieldDataProvider = fieldDataProvider;
        _movementDuration = fieldVisualizationParameters.MovementDuration;
        _swapDuration = fieldVisualizationParameters.SwapDuration;
    }

    public async Task MoveAsync(IChip chip, int newX, int newY)
    {
        chip.X = newX;
        chip.Y = newY;

        chip.MyGo.transform.DOMove(_chipPositionProvider.GetPosition(newX, newY), _movementDuration);
        await new WaitForEndOfFrame();
    }

    public async Task<bool> SwapAsync(IChip chip1, IChip chip2)
    {
        int tempX = chip1.X;
        int tempY = chip1.Y;

        if (chip1.IsMovable && chip2.IsMovable)
        {
            GameField.FieldMatrix[chip1.X, chip1.Y] = chip2;
            GameField.FieldMatrix[chip2.X, chip2.Y] = chip1;

            chip1.X = chip2.X; 
            chip1.Y = chip2.Y;
            chip2.X = tempX;
            chip2.Y = tempY;

            chip1.MyGo.transform.DOMove(_chipPositionProvider.GetPosition(chip1.X, chip1.Y), _swapDuration);
            chip2.MyGo.transform.DOMove(_chipPositionProvider.GetPosition(chip2.X, chip2.Y), _swapDuration);
            await new WaitForSeconds(_swapDuration);
        }

        return OnMovementDone();
    }

    private bool OnMovementDone()
    {
        return true;
    }

}