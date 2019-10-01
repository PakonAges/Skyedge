using System.Collections.Generic;

public interface IMatchChecker
{
    List<ColorChip> GetMatch(IChip chip);
}
