namespace Meddle
{
    /// <summary>
    /// Adds an method to be run 
    /// before the data is inserted.
    /// </summary>
    public interface IAddable
    {
        void OnAdding(IWork work);
    }
}
