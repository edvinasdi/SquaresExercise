namespace SquaresAPI.Data.Repositories
{
    public class DatabaseStatusRepository : IDatabaseStatusRepository
    {
        private readonly ApiDbContext _context;

        public DatabaseStatusRepository(ApiDbContext context)
        {
            _context = context;
        }

        public bool CanConnect()
        {
            return _context.Database.CanConnect();
        }
    }
}
