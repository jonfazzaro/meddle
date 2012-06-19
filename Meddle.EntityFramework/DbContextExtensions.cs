using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Objects;

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

        public static void SetContextOnMaterialization<T>(this DbContext context)
            where T : DbContext
        {
            (context as IObjectContextAdapter).ObjectContext.ObjectMaterialized +=
                delegate(object sender, ObjectMaterializedEventArgs e)
                {
                    (e.Entity as IEntityWithDbContext<T>).Context = context as T;
                };
        }
    }
}
