using System.Threading.Tasks;

public interface IFieldCleaner
{
    Field GameField { get; set; }
    void ClearAndRefillBoard();
    Task<bool> ClearChipAsync(int x, int y);
    Task<bool> ClearAllMathcesAndNeedsToRefillAsync();
}
