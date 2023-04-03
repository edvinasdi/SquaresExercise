namespace SquaresAPI.Data.Repositories
{
    public interface IDatabaseStatusRepository
    {
        public bool CanConnect();
    }
}
