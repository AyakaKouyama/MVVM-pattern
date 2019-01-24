using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Logic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Zadanie3;
namespace Test
{
    [TestClass]
    public class ExtensionMethodsTest
    {
        [TestMethod]
        public void NullCategoryTest()
        {
            using (DataBaseDataContext db = new DataBaseDataContext())
            {
                List<Product> res = db.Product.NullCategory();

                Assert.AreEqual(res.Count, 209);
            }
        }

        [TestMethod]
        public void PageTest()
        {
            using (DataBaseDataContext db = new DataBaseDataContext())
            {
                List<Product> res = db.Product.Page(50, 1);

                Assert.AreEqual(res.Count, 50);
                Assert.AreEqual(res[0].Name, "Adjustable Race");
                Assert.AreEqual(res[0].ProductID, 1);
                Assert.AreEqual(res[49].Name, "Thin-Jam Hex Nut 7");
                Assert.AreEqual(res[49].ProductID, 371);

                res.Clear();
                res = db.Product.Page(25, 3);
                Assert.AreEqual(res.Count, 25);
                Assert.AreEqual(res[0].Name, "Thin-Jam Hex Nut 8");
                Assert.AreEqual(res[0].ProductID, 372);
                Assert.AreEqual(res[24].Name, "Hex Nut 18");
                Assert.AreEqual(res[24].ProductID, 396);

                res.Clear();
                res = db.Product.Page(10, 3);
                Assert.AreEqual(res.Count, 10);
                Assert.AreEqual(res[0].Name, "Freewheel");
                Assert.AreEqual(res[0].ProductID, 332);
                Assert.AreEqual(res[9].Name, "Flat Washer 7");
                Assert.AreEqual(res[9].ProductID, 349);
            }
        }

        [TestMethod]
        public void NullCategoryFromTest()
        {
            using (DataBaseDataContext db = new DataBaseDataContext())
            {
                List<Product> result = db.Product.NullCategoryFrom();
                Assert.AreEqual(result.Count, 209);
            }
        }

        [TestMethod]
        public void PageFromTest()
        {
            using (DataBaseDataContext db = new DataBaseDataContext())
            {
                List<Product> res = db.Product.PageFrom(50, 1);

                Assert.AreEqual(res.Count, 50);
                Assert.AreEqual(res[0].Name, "Adjustable Race");
                Assert.AreEqual(res[0].ProductID, 1);
                Assert.AreEqual(res[49].Name, "Thin-Jam Hex Nut 7");
                Assert.AreEqual(res[49].ProductID, 371);

                res.Clear();
                res = db.Product.Page(25, 3);
                Assert.AreEqual(res.Count, 25);
                Assert.AreEqual(res[0].Name, "Thin-Jam Hex Nut 8");
                Assert.AreEqual(res[0].ProductID, 372);
                Assert.AreEqual(res[24].Name, "Hex Nut 18");
                Assert.AreEqual(res[24].ProductID, 396);

                res.Clear();
                res = db.Product.Page(10, 3);
                Assert.AreEqual(res.Count, 10);
                Assert.AreEqual(res[0].Name, "Freewheel");
                Assert.AreEqual(res[0].ProductID, 332);
                Assert.AreEqual(res[9].Name, "Flat Washer 7");
                Assert.AreEqual(res[9].ProductID, 349);
            }
        }

    }
}
