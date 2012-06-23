namespace Meddle
{
    /// <summary>
    /// Adds an method to be run
    /// before the data is deleted.
    /// </summary>
    public interface IDeletable
    {
        void OnDeleting();
    }
}
