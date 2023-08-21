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

    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        CaseContext context { get; set; }
        public ProductRepository(CaseContext _context) : base(_context)
        {
            context = _context;
        }

        public List<Product> FilterProducts(string sortOrder, string category)
        {
            string query = $"select p.* from Products p left join Categories c on c.Id = p.CategoryId where p.IsDeleted = 0 and c.IsDeleted = 0 ";
            if (category != "all")
                query += $" and p.CategoryId = '{category}' ";
            
                
            switch (sortOrder)
            {

                case "price_asc":
                    query += " order by p.Price asc ";
                    break;
                case "price_desc":
                    query += " order by p.Price desc ";
                    break;
                case "default":
                    break;

            }
            var res = context.Products.FromSqlRaw(query);
            var fda = res.ToList();


            return fda;
        }

        public override List<Product> GetAll()
        {
           
            base.GetAll();
            var products = context.Products
                .Include(p => p.Category)
                .Where(p=> !p.IsDeleted && !p.Category.IsDeleted).ToList();
            return products;
          
            
        }
    }
}
