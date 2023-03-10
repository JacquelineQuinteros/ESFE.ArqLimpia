using ESFE.ArqLimpia.EN.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESFE.ArqLimpia.DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        readonly ESFEDbContext dbContext;

        public UnitOfWork(ESFEDbContext pDbContext) 
        {
            dbContext = pDbContext;
        }

        public Task<int> SaveChangesAsync()
        {
            return dbContext.SaveChangesAsync();
        }
    }
}
