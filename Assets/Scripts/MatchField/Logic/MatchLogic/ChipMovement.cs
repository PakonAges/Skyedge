using DG.Tweening;
using System.Threading.Tasks;
using UnityEngine;

public class ChipMovement : IChipMovement
{
    readonly IChipPositionProvider _chipPositionProvider;
    readonly float _movementDuration;

    public ChipMovement (   IChipPositionProvider chipPositionProvider,
                            FieldVisualizationParameters fieldVisualizationParameters)
    {
        _chipPositionProvider = chipPositionProvider;
        _movementDuration = fieldVisualizationParameters.MovementDuration;
    }

    public async Task<bool> Move(Chip chip, int newX, int newY)
    {
        chip.X = newX;
        chip.Y = newY;
        //chip.Position = _chipPositionProvider.GetPosition(newX, newY);

        chip.gameObject.transform.DOMove(_chipPositionProvider.GetPosition(newX, newY), _movementDuration);
        await new WaitForSeconds(_movementDuration);
        return OnMovementDone();
    }

    private bool OnMovementDone()
    {
        return true;
    }
}