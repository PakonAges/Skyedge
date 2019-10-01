using System.Threading.Tasks;

public interface IFieldCleaner
{
    void ClearAllBoard();
    Task ClearAndRefillBoardAsync();
    bool ClearChip(int x, int y);
    Task ClearChipAndRefillAsync(int x, int y);
    bool ClearAllMathcesAndNeedsToRefill();
    void ChangeFillDirection(int chip1_x, int chip1_y, int chip2_x, int chip2_y);
    void ChangeFillDirection(MoveDirection moveDirection);
}
