using CaseDAL.Abstract;
using CaseEntity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseDAL.Concrete.MySQL
{
    public class UserRepository : GenericRepository<User>,IUserRepository
    {
        CaseContext context { get; set; }
        public UserRepository(CaseContext _context) : base(_context)
        {
            context = _context;
        }

        public async Task<User?> GetByEmailAndPasswordAsync(string email , string password)
        {
            var user = await context.Users.Where(i => i.Email == email && i.Password == password).FirstOrDefaultAsync();
            return user;
        }
    }
}
