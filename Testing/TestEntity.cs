using Meddle;

namespace Testing
{
    public class TestEntity : IAddable, IUpdatable, IDeletable
    {

        public bool MeddledOnAdding { get; private set; }
        public bool MeddledOnUpdating { get; private set; }
        public bool MeddledOnDeleting { get; private set; }
        
        public void OnAdding(IWork work)
        {
            this.MeddledOnAdding = true;
        }

        public void OnUpdating(IWork work)
        {
            this.MeddledOnUpdating = true;
        }

        public void OnDeleting(IWork work)
        {
            this.MeddledOnDeleting = true;
        }
    }
}
