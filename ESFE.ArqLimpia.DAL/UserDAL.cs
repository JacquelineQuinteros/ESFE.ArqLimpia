using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ESFE.ArqLimpia.EN;
using ESFE.ArqLimpia.EN.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ESFE.ArqLimpia.DAL
{
    public class UserDAL : IUser
    {
        readonly ESFEDbContext dbContext;

        public UserDAL(ESFEDbContext pDbContext)
        {
            dbContext = pDbContext;
        }

        public void Create(User pUser)
        {
            dbContext.Add(pUser);
        }

        public void Delete(User pUser)
        {
            dbContext.Remove(pUser);
        }

        public async Task<User> GetById(User pUser)
        {
            User? user = await dbContext.User.FirstOrDefaultAsync(s => s.Id == pUser.Id);
            if (user != null) return user;
            else return new User();
        }

        public Task<List<User>> Search(User pUser)
        {
            var query = dbContext.User.AsQueryable();

            if (!string.IsNullOrWhiteSpace(pUser.Name))
                query = query.Where(s => s.Name.Contains(pUser.Name));
            if (!string.IsNullOrWhiteSpace(pUser.Email))
                query = query.Where(s => s.Email == pUser.Email);
            return query.ToListAsync();
        }

        public void Update(User pUser)
        {
            dbContext.Update(pUser);
        }
    }
}
