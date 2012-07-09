namespace Meddle
{
    /// <summary>
    /// Adds an method to be run 
    /// before the data is updated.
    /// </summary>
    public interface IUpdatable
    {
        void OnUpdating(IWork work);
    }
}
