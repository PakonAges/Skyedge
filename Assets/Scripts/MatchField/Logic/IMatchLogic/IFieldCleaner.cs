public interface IFieldCleaner
{
    Field GameField { get; set; }
    bool ClearChip(int x, int y);
    bool ClearAllValidMathces();
}
