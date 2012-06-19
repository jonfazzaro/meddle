using Meddle.EntityFramework;

namespace Testing
{
    public interface IEntityWithAdventureWorksEntitiesContext 
        : IEntityWithObjectContext<AdventureWorksEntities>
    {
    }
}
