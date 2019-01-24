using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie3
{
    public static class FromExtension
    {
        public static List<Product> NullCategoryFrom(this IEnumerable<Product> product)
        {
            IEnumerable<Product> res = from i in product
                                       where i.ProductSubcategoryID == null
                                       select i;

            return res.ToList();
        }

        public static List<Product> PageFrom(this IEnumerable<Product> product, int pageSize, int pageNumber)
        {
            IEnumerable<Product> res = (from i in product
                                       select i).Skip(pageSize * (pageNumber - 1)).Take(pageSize);

            return res.ToList();
        }

    }
}
