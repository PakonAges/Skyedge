using System.Collections.Generic;

public interface IMatchChecker
{
    Field GameField { get; set; }
    List<ColorChip> GetMatch(IChip chip);
}
