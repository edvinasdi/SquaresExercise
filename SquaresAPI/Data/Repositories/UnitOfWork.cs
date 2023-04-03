﻿namespace SquaresAPI.Data.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApiDbContext _context;

        public UnitOfWork(ApiDbContext context)
        {
            _context = context;
        }

        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
