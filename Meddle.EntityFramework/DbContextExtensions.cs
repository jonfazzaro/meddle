using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace Meddle.EntityFramework
{
    public static class DbContextExtensions
    {
        public static IEnumerable<IAddable> GetAdded(this DbContext context)
        {
            return (context as IObjectContextAdapter).ObjectContext.GetAdded();
        }

        public static IEnumerable<IUpdatable> GetUpdated(this DbContext context)
        {
            return (context as IObjectContextAdapter).ObjectContext.GetUpdated();
        }

        public static IEnumerable<IDeletable> GetDeleted(this DbContext context)
        {
            return (context as IObjectContextAdapter).ObjectContext.GetDeleted();
        }
    }
}
