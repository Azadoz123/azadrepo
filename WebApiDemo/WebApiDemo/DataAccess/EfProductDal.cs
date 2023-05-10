using Microsoft.EntityFrameworkCore;
using WebApiDemo.Entities;
using WebApiDemo.Models;

namespace WebApiDemo.DataAccess
{
    public class EfProductDal : EfEntityRepositoryBase<Product>, IProductDal
    {
        private readonly Northwind _context;
        public EfProductDal(Northwind context) : base(context)
        {
            _context = context;
        }

        public List<ProductModel> GetProductsWithDetails() 
        {
            var result = from p in _context.Products
                         join c in _context.Categories
                         on p.CategoryId equals c.CategoryId
                         select new ProductModel
                         {
                             ProductId = p.ProductId,
                             ProductName = p.ProductName,
                             CategoryName = c.CategoryName,
                             UnitPrice = p.UnitPrice
                         };
            return result.ToList();
        }
    }
}
