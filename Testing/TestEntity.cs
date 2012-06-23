using Meddle;

namespace Testing
{
    public class TestEntity : IAddable, IUpdatable, IDeletable
    {

        public bool MeddledOnAdding { get; private set; }
        public bool MeddledOnUpdating { get; private set; }
        public bool MeddledOnDeleting { get; private set; }
        
        public void OnAdding()
        {
            this.MeddledOnAdding = true;
        }

        public void OnUpdating()
        {
            this.MeddledOnUpdating = true;
        }

        public void OnDeleting()
        {
            this.MeddledOnDeleting = true;
        }
    }
}
