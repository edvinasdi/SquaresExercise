namespace SquaresAPI.Data.Repositories
{
    public interface IUnitOfWork
    {
        public Task CompleteAsync();
    }
}
