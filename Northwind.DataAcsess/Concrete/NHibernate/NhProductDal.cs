using Northwind.DataAcsess.Abstract;
using Northwind.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.DataAcsess.Concrete.NHibernate
{
    public class NhProductDal : IProductDal
    {
        public void Add(Product entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Product entity)
        {
            throw new NotImplementedException();
        }

        
        public Product Get(Expression<Func<Product, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            List<Product> products = new List<Product>
            {
                new Product{
                    ProductId =1,
                    ProductName="Laptop",
                    CategoryId=2,
                    UnitPrice=3000,
                    UnitsInStock= 11,
                    QuantityPerUnit="1 in a box" }
            };
            return products;
        }

        public void Update(Product entity)
        {
            throw new NotImplementedException();
        }
    }
}
