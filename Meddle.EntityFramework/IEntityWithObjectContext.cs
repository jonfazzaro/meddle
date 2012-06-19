using System.Data.Objects;

namespace Meddle.EntityFramework
{
    public interface IEntityWithObjectContext<T> 
        where T : ObjectContext
    {
        T Context { get; set; }
    }
}
