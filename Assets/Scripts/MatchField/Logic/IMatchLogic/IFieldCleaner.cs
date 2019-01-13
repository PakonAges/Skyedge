using System.Threading.Tasks;

public interface IFieldCleaner
{
    Field GameField { get; set; }
    void ClearAllBoard();
    Task ClearAndRefillBoardAsync();
    Task<bool> ClearChipAsync(int x, int y);
    Task ClearChipAndRefillAsync(int x, int y);
    Task<bool> ClearAllMathcesAndNeedsToRefillAsync();
    void ChangeFillDirection(int chip1_x, int chip1_y, int chip2_x, int chip2_y);
}
