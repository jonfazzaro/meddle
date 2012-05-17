namespace Meddle
{
    public class Meddler
    {
        public Meddler(IWork work)
        {
            this.Work = work;
        }

        /// <summary>
        /// Gets or sets the unit of work 
        /// with which to meddle.
        /// </summary>
        public IWork Work { get; set; }

        /// <summary>
        /// Executes custom logic against added, 
        /// updated, and deleted entities.
        /// </summary>
        public void Meddle()
        {
            foreach (var e in this.Work.Added)
                e.OnAdding(this.Work);

            foreach (var e in this.Work.Updated)
                e.OnUpdating(this.Work);

            foreach (var e in this.Work.Deleted)
                e.OnDeleting(this.Work);
        }

        /// <summary>
        /// Executes custom logic against added, 
        /// updated, and deleted entities in the
        /// given unit of work.
        /// </summary>
        public static void Meddle(IWork work)
        {
            var meddler = new Meddler(work);
            meddler.Meddle();
        }
    }
}

