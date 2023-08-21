using CaseDAL.Abstract;
using CaseEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseDAL.Concrete.MySQL
{
    public class CategoryRepository : GenericRepository<Category>,ICategoryRepository
    {
        CaseContext context { get; set; }
        public CategoryRepository(CaseContext _context) : base(_context)
        {
            context = _context;
        }
    }
}
