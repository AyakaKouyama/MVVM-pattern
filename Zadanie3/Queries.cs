using System;
using System.Collections.Generic;
using System.Data.Linq.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie3
{
    public class Queries
    {

        public static List<Product> GetAllProducts()
        {
            using (DataBaseDataContext db = new DataBaseDataContext())
            {
                IQueryable <Product> res = db.Product;
                return res.ToList();
            }
        }
        public static List<Product> GetProductsByName(string namePart)
        {
            using (DataBaseDataContext db = new DataBaseDataContext())
            {
                IQueryable<Product> result = db.Product.Where(n => n.Name.Contains(namePart));

                return result.ToList();
            }
        }

        public static List<Product> GetProductsByVendorName(string vendorName)
        {
            using (DataBaseDataContext db = new DataBaseDataContext())
            {
                IQueryable<Product> result = from i in db.Product
                                             from j in db.Vendor
                                             from k in db.ProductVendor
                                             where j.Name == vendorName && k.ProductID == i.ProductID && k.BusinessEntityID == j.BusinessEntityID
                                             select i;

                return result.ToList();
            }
        }

        public static List<string> GetProductNamesByVendorName(string vendorName)
        {
            using (DataBaseDataContext db = new DataBaseDataContext())
            {
                IQueryable<string> result = from i in db.Product
                                            from j in db.Vendor
                                            from k in db.ProductVendor
                                            where j.Name == vendorName && k.ProductID == i.ProductID && k.BusinessEntityID == j.BusinessEntityID
                                            select i.Name;

                return result.ToList();
            }
        }

        public static string GetProductVendorByProductName(string productName)
        {
            using (DataBaseDataContext db = new DataBaseDataContext())
            {
                IQueryable<string> result = from i in db.Vendor
                                            from j in db.ProductVendor
                                            from k in db.Product
                                            where k.ProductID == j.ProductID && j.BusinessEntityID == i.BusinessEntityID
                                                  && k.Name == productName
                                            select i.Name;

                return result.ToArray()[0];
            }
        }

        public static List<Product> GetProductsWithNRecentReviews(int howManyReviews)
        {
            using (DataBaseDataContext db = new DataBaseDataContext())
            {
                IQueryable<Product> result = (from i in db.Product
                                              from j in db.ProductReview
                                              orderby j.ReviewDate
                                              where i.ProductID == j.ProductID
                                              select i).Take(howManyReviews);

                return result.ToList();
            }
        }

        public static List<Product> GetNRecentlyReviewedProducts(int howManyProducts)
        {
            using (DataBaseDataContext db = new DataBaseDataContext())
            {
                IQueryable<Product> result = (from i in db.Product
                                              from j in db.ProductReview
                                              orderby j.ReviewDate
                                              where i.ProductID == j.ProductID
                                              select i).Take(howManyProducts);

                return result.ToList();
            }
        }

        public static List<Product> GetNProductsFromCategory(string categoryName, int n)
        {
            using (DataBaseDataContext db = new DataBaseDataContext())
            {
                IQueryable<Product> result = (from i in db.Product
                                              from j in db.ProductSubcategory
                                              from k in db.ProductCategory
                                              orderby i.Name, k.Name
                                              where i.ProductSubcategoryID == j.ProductSubcategoryID && j.ProductCategoryID == k.ProductCategoryID &&
                                                    k.Name == categoryName
                                              select i).Take(n);
                return result.ToList();
            }
        }


        public static int GetTotalStandardCostByCategory(ProductCategory category)
        {
            using (DataBaseDataContext db = new DataBaseDataContext())
            {
                Decimal result = (from i in db.Product
                                  from j in db.ProductSubcategory
                                  where i.ProductSubcategoryID == j.ProductSubcategoryID && j.ProductCategory.Name == category.Name
                                  select i.StandardCost).Sum();

                return (int)result;
            }

        }

    }
}
