using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Zadanie3;
namespace Test
{
    [TestClass]
    public class QueriesTest
    {


        [TestMethod]
        public void GetProductsByNameTest()
        {
            using (DataBaseDataContext db = new DataBaseDataContext())
            {
                List<Product> res = Queries.GetProductsByName("Tights");
                Assert.AreEqual(res.Count, 3);
                Assert.IsTrue(res.Exists(o => o.Name.Equals("Women's Tights, L")));
                Assert.IsTrue(res.Exists(o => o.Name.Equals("Women's Tights, M")));
                Assert.IsTrue(res.Exists(o => o.Name.Equals("Women's Tights, S")));
                Assert.IsTrue(res.Exists(o => o.ProductID == 852));
                Assert.IsTrue(res.Exists(o => o.ProductID == 853));
                Assert.IsTrue(res.Exists(o => o.ProductID == 854));

                res = Queries.GetProductsByName("Crankset");
                Assert.AreEqual(res.Count, 3);
                Assert.IsTrue(res.Exists(o => o.Name.Equals("LL Crankset")));
                Assert.IsTrue(res.Exists(o => o.Name.Equals("ML Crankset")));
                Assert.IsTrue(res.Exists(o => o.Name.Equals("HL Crankset")));
                Assert.IsTrue(res.Exists(o => o.ProductID == 949));
                Assert.IsTrue(res.Exists(o => o.ProductID == 950));
                Assert.IsTrue(res.Exists(o => o.ProductID == 951));
            }
        }

        [TestMethod]
        public void GetProductsByVendorName()
        {
            using (DataBaseDataContext db = new DataBaseDataContext())
            {
                List<Product> res = Queries.GetProductsByVendorName("Australia Bike Retailer");

                Assert.AreEqual(res.Count, 16);
                for (int i = 1; i <= 16; i++)
                {
                    Assert.IsTrue(res.Exists(o => o.Name.Equals("Thin-Jam Lock Nut " + i)));
                }

                for (int i = 422; i <= 437; i++)
                {
                    Assert.IsTrue(res.Exists(o => o.ProductID == i));
                }
            }
        }

        [TestMethod]
        public void GetProductNamesByVendorNameTest()
        {
            using (DataBaseDataContext db = new DataBaseDataContext())
            {
                List<Product> res = Queries.GetProductsByVendorName("Wood Fitness");

                Assert.AreEqual(res.Count, 1);
                Assert.AreEqual(res[0].Name, "Bearing Ball");
                Assert.AreEqual(res[0].ProductID, 2);
            }
        }

        [TestMethod]
        public void GetNRecentlyReviewedProductsTest()
        {
            using (DataBaseDataContext db = new DataBaseDataContext())
            {
                List<Product> result = Queries.GetNRecentlyReviewedProducts(2);
                Assert.AreEqual(result[0].Name, "Mountain Bike Socks, M");
                Assert.AreEqual(result[0].ProductID, 709);
                Assert.AreEqual(result[1].Name, "HL Mountain Pedal");
                Assert.AreEqual(result[1].ProductID, 937);
            }

        }

        [TestMethod]
        public void GetProductsWithNRecentReviewsTets()
        {
            using (DataBaseDataContext db = new DataBaseDataContext())
            {
                List<Product> result = Queries.GetNRecentlyReviewedProducts(2);
                Assert.AreEqual(result[0].Name, "Mountain Bike Socks, M");
                Assert.AreEqual(result[0].ProductID, 709);
                Assert.AreEqual(result[1].Name, "HL Mountain Pedal");
                Assert.AreEqual(result[1].ProductID, 937);
            }
        }

        [TestMethod]
        public void GetProductVendorByProductName()
        {
            using (DataBaseDataContext db = new DataBaseDataContext())
            {
                Assert.IsTrue(Queries.GetProductVendorByProductName("Thin-Jam Lock Nut 1").Equals("Australia Bike Retailer"));
                Assert.IsTrue(Queries.GetProductVendorByProductName("Adjustable Race").Equals("Litware, Inc."));
                Assert.IsTrue(Queries.GetProductVendorByProductName("Bike Wash - Dissolver").Equals("Green Lake Bike Company"));
                Assert.IsTrue(Queries.GetProductVendorByProductName("External Lock Washer 8").Equals("Aurora Bike Center"));
                Assert.IsTrue(Queries.GetProductVendorByProductName("Freewheel").Equals("Sport Playground"));
            }
        }

        [TestMethod]
        public void GetNProductsFromCategoryTest()
        {
            using (DataBaseDataContext db = new DataBaseDataContext())
            {
                List<Product> result = Queries.GetNProductsFromCategory("Accessories", 3);
                Assert.AreEqual(result[0].Name, "All-Purpose Bike Stand");
                Assert.AreEqual(result[0].ProductID, 879);
                Assert.AreEqual(result[1].Name, "Bike Wash - Dissolver");
                Assert.AreEqual(result[1].ProductID, 877);
                Assert.AreEqual(result[2].Name, "Cable Lock");
                Assert.AreEqual(result[2].ProductID, 843);
            }
        }

        [TestMethod]
        public void GetTotalStandardCostByCategory()
        {
            using (DataBaseDataContext db = new DataBaseDataContext())
            {
                ProductCategory cat = new ProductCategory();
                cat.Name = "Accessories";
                int result = Queries.GetTotalStandardCostByCategory(cat);
                Assert.AreEqual(result, 383);
            }
        }
    }
}
