using Domain.Commands.Interfaces;
using Infra.Data.Context;

namespace Infra.Data.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly TestTaskDbContext _context;

        public UnitOfWork(TestTaskDbContext context)
        {
            _context = context;
        }

        public bool Commit()
        {
            return _context.SaveChanges() > 0;
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}