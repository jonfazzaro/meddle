using System.Collections.Generic;
using System.Data;
using System.Data.Objects;
using System.Linq;

namespace Meddle.EntityFramework
{
    public static class ObjectContextExtensions
    {
        public static IEnumerable<IAddable> GetAdded(this ObjectContext context)
        {
            return Get<IAddable>(context, EntityState.Added);
        }

        public static IEnumerable<IUpdatable> GetUpdated(this ObjectContext context)
        {
            return Get<IUpdatable>(context, EntityState.Modified);
        }

        public static IEnumerable<IDeletable> GetDeleted(this ObjectContext context)
        {
            return Get<IDeletable>(context, EntityState.Deleted);
        }

        private static IEnumerable<T> Get<T>(ObjectContext context, EntityState state) where T : class
        {
            return context.ObjectStateManager
                .GetObjectStateEntries(state)
                .Where(e => e.Entity is T)
                .Select(e => e.Entity as T);
        }

        public static void SetContextOnMaterialization<T>(this ObjectContext context)
            where T : ObjectContext
        {
            context.ObjectMaterialized += 
                delegate(object sender, ObjectMaterializedEventArgs e) {
                    (e.Entity as IEntityWithObjectContext<T>).Context = context as T;
                };
        }

    }
}
