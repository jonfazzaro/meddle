using Meddle.EntityFramework;

namespace Testing
{
    partial class Contact : IEntityWithAdventureWorksEntitiesContext
    {
        public AdventureWorksEntities Context { get; set; }
    }
}
