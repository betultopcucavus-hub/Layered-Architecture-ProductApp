using Northwind.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.DataAcsess.Concrete.EntityFramework
{
  public class EfNorthwindContext:DbContext
    {
        public DbSet<Product>Products { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
