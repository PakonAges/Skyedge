public interface IFieldCleaner
{
    Field GameField { get; set; }
    void ClearAndRefillBoard();
    bool ClearChip(int x, int y);
    bool ClearAllMathcesAndNeedsToRefill();
}
