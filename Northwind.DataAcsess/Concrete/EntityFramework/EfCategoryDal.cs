using Northwind.DataAcsess.Abstract;
using Northwind.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.DataAcsess.Concrete.EntityFramework
{
  public class EfCategoryDal:EfEntityRepositoryBase<Category,EfNorthwindContext>,ICategoryDal
    {
    }
}
