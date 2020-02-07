using Microsoft.EntityFrameworkCore;
using CadSage.Domain.Interfaces;
using CadSage.Infra.Data.Context;
using System;
using System.Linq;

namespace CadSage.Infra.Data.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly CadSageContext _context;

        public UnitOfWork(CadSageContext context)
        {
            _context = context;
        }

        public string Commit()
        {
            try
            {
                _context.SaveChanges();
                return null;
            }
            catch(Exception e)
            {
                RollBack();
                return e.ToString();
            }
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public void RollBack()
        {
            var changedEntries = _context.ChangeTracker.Entries().Where(x => x.State != EntityState.Unchanged).ToList();

            foreach (var entry in changedEntries)
            {
                switch (entry.State)
                {
                    case EntityState.Modified:
                        entry.CurrentValues.SetValues(entry.OriginalValues);
                        entry.State = EntityState.Unchanged;
                        break;
                    case EntityState.Added:
                        entry.State = EntityState.Detached;
                        break;
                    case EntityState.Deleted:
                        entry.State = EntityState.Unchanged;
                        break;
                }
            }
        }
    }
}