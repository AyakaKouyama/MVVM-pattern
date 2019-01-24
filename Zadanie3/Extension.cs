using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie3
{
    public static class Extension
    {
        public static List<Product> NullCategory(this IEnumerable<Product> product)
        {
            return product.Where(o => o.ProductSubcategoryID == null).ToList();
        }

        public static List<Product> Page(this IEnumerable<Product> product, int pageSize, int pageNumber)
        {
            return product.Skip(pageSize * (pageNumber - 1)).Take(pageSize).ToList();
        }

        public static string FormattedName(this IEnumerable<Product> product)
        {
            using (DataBaseDataContext db = new DataBaseDataContext())
            {
                var res = from i in product
                          from j in db.Vendor
                          from k in db.ProductVendor
                          where k.ProductID == i.ProductID && j.BusinessEntityID == k.BusinessEntityID
                          select new { id = i.ProductID, name = j.Name };

                StringBuilder s = new StringBuilder();
                foreach (var i in res)
                {
                    s.AppendFormat("{0}-{1}\n", i.id, i.name);
                }

                return s.ToString();
            }
        }
    }
}
