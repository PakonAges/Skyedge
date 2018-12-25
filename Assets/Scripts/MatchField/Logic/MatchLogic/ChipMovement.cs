using DG.Tweening;
using System.Threading.Tasks;
using UnityEngine;

public class ChipMovement : IChipMovement
{
    readonly IChipPositionProvider _chipPositionProvider;

    public ChipMovement (   IChipPositionProvider chipPositionProvider)
    {
        _chipPositionProvider = chipPositionProvider;
    }

    public async Task Move(Chip chip, int newX, int newY)
    {
        chip.X = newX;
        chip.Y = newY;
        //chip.Position = _chipPositionProvider.GetPosition(newX, newY);

       chip.gameObject.transform.DOMove(_chipPositionProvider.GetPosition(newX, newY),1.0f);
       await new WaitForSeconds(1.0f);
    }
}