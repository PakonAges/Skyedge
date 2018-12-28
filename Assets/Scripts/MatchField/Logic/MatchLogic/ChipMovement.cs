﻿using DG.Tweening;
using System.Threading.Tasks;
using UnityEngine;

public class ChipMovement : IChipMovement
{
    readonly IChipPositionProvider _chipPositionProvider;
    readonly float _movementDuration;
    public Field GameField { get; set; }

    public ChipMovement(IChipPositionProvider chipPositionProvider,
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

    public async Task<bool> Swap(Chip chip1, Chip chip2)
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

            chip1.gameObject.transform.DOMove(_chipPositionProvider.GetPosition(chip1.X, chip1.Y), _movementDuration);
            chip2.gameObject.transform.DOMove(_chipPositionProvider.GetPosition(chip2.X, chip2.Y), _movementDuration);
            await new WaitForSeconds(_movementDuration);
        }
        return OnMovementDone();

        //Change movement direction!
    }

    private bool OnMovementDone()
    {
        return true;
    }
}