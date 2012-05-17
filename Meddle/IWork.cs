using System.Collections.Generic;

namespace Meddle
{
    /// <summary>
    /// Provides methods for retrieving
    /// changes from a unit of work.
    /// </summary>
    public interface IWork
    {
        IEnumerable<IAddable> Added { get; }
        IEnumerable<IUpdatable> Updated { get; }
        IEnumerable<IDeletable> Deleted { get; }
    }
}
