using System.Data.Entity;

namespace Meddle.EntityFramework
{
    public interface IEntityWithDbContext<T>
        where T : DbContext
    {
        T Context { get; set; }
    }
}
