using System;
using System.Collections.Generic;
using System.Data.Linq.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie3
{
    public class MyProductList
    {
        private List<MyProduct> myProduct;

        public MyProductList()
        {
            myProduct = new List<MyProduct>();
        }

        public List<MyProduct> MyProduct { get => myProduct; set => myProduct = value; }

        public void Fill()
        {
            using (DataBaseDataContext db = new DataBaseDataContext())
            {
                IEnumerable<Product> res = from i in db.Product
                                           select i;

                int j = 0;
                foreach (Product i in res)
                {
                    MyProduct.Add(new MyProduct());
                    MyProduct[j].ProductId = i.ProductID;
                    MyProduct[j].Name = i.Name;
                    MyProduct[j].ProductNumber = i.ProductNumber;
                    MyProduct[j].MakeFlag = i.MakeFlag;
                    MyProduct[j].FinishedGoodsFlag = i.FinishedGoodsFlag;
                    MyProduct[j].Color = i.Color;
                    MyProduct[j].SafetyLockLevel = i.SafetyStockLevel;
                    MyProduct[j].ReorderPoint = i.ReorderPoint;
                    MyProduct[j].StandartCost = (float)i.StandardCost;
                    MyProduct[j].ListPrice = (float)i.ListPrice;
                    MyProduct[j].Size = i.Size;
                    MyProduct[j].SizeUnitMeasureCode = i.SizeUnitMeasureCode;
                    MyProduct[j].WeightUnitMeasureCode = i.WeightUnitMeasureCode;
                    MyProduct[j].Weight = i.Weight == 0 ? "0" : i.Weight.ToString();
                    MyProduct[j].DaysToManufacture = i.DaysToManufacture;
                    MyProduct[j].ProductionLine = i.ProductLine;
                    MyProduct[j].ProductId = i.ProductID;
                    MyProduct[j].Class = i.Class;
                    MyProduct[j].Style = i.Style;
                    MyProduct[j].ProductSubcategoryID = i.ProductSubcategoryID == null ? 0 : (int)i.ProductSubcategoryID;
                    MyProduct[j].ProductModeID = i.ProductModelID == null ? 0 : (int)i.ProductModelID;
                    MyProduct[j].SellStartDate = i.SellStartDate.ToString();
                    MyProduct[j].SellEndDate = i.SellEndDate.ToString();
                    MyProduct[j].DiscountedDate = i.DiscontinuedDate.ToString();
                    MyProduct[j].RowGuid = i.rowguid.ToString();
                    MyProduct[j].ModifyDate = i.ModifiedDate.ToString();

                    j++;
                }
            }

        }

        public List<MyProduct> MyProductGetProductsByName(string namePart)
        {

            IEnumerable<MyProduct> result = myProduct.Where(n => n.Name.Contains(namePart));
            return result.ToList();
        }

        public List<MyProduct> MyProductGetProductsWithNRecentReviews(int howManyReviews)
        {
            using (DataBaseDataContext db = new DataBaseDataContext())
            {
                IEnumerable<MyProduct> result = (from i in myProduct
                                                 from j in db.ProductReview
                                                 orderby j.ReviewDate
                                                 where i.ProductId == j.ProductID
                                                 select i).Take(howManyReviews);

                return result.ToList();
            }
        }


        public List<MyProduct> MyListGetNProductsFromCategory(string categoryName, int n)
        {
            using (DataBaseDataContext db = new DataBaseDataContext())
            {

                IEnumerable<MyProduct> res = (from i in myProduct
                                              from j in db.ProductSubcategory
                                              from k in db.ProductCategory
                                              orderby k.Name, i.Name
                                              where k.Name == categoryName && i.ProductSubcategoryID == j.ProductSubcategoryID && j.ProductCategoryID == k.ProductCategoryID
                                              select i).Take(n);

                return res.ToList();
            }
        }



    }
}
