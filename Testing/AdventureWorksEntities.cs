using System.Collections.Generic;
using System.Data.Objects;
using Meddle;
using Meddle.EntityFramework;

namespace Testing
{
    public partial class AdventureWorksEntities : IWork
    {
        partial void OnContextCreated()
        {
            this.SetContextOnMaterialization<AdventureWorksEntities>();
        }

        public override int SaveChanges(SaveOptions options)
        {
            Meddler.Meddle(this); // here's where the meddle happens \m/
            return base.SaveChanges(options);
        }

        public IEnumerable<IAddable> Added
        {
            get { return this.GetAdded(); }
        }

        public IEnumerable<IDeletable> Deleted
        {
            get { return this.GetDeleted(); }
        }

        public IEnumerable<IUpdatable> Updated
        {
            get { return this.GetUpdated(); }
        }
    }
}
