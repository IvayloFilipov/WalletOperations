namespace Services
{
    public interface IPlay
    {
        // A single asynchronous method. Returning a Task allows for asynchronous operations.
        Task RunAsync();
    }
}
