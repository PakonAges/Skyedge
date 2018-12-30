using System.Collections.Generic;

public interface IMatchChecker
{
    Field GameField { get; set; }
    List<Chip> GetMatch(Chip chip, int newX, int newY);
}
