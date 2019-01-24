using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Zadanie3;

namespace Test
{
    [TestClass]
    public class MyProductQueriesTest
    {
        MyProductList list = new MyProductList();

        public MyProductQueriesTest()
        {
            list.Fill();
        }

        [TestMethod]
        public void MyListGetProductsByNameTest()
        {
            Assert.AreEqual(list.MyProductGetProductsByName("Tights").Count, 3);
            Assert.IsTrue(list.MyProductGetProductsByName("Tights").Exists(o => o.Name.Equals("Women's Tights, L")));
            Assert.IsTrue(list.MyProductGetProductsByName("Tights").Exists(o => o.Name.Equals("Women's Tights, M")));
            Assert.IsTrue(list.MyProductGetProductsByName("Tights").Exists(o => o.Name.Equals("Women's Tights, S")));
            Assert.IsTrue(list.MyProductGetProductsByName("Tights").Exists(o => o.ProductId == 852));
            Assert.IsTrue(list.MyProductGetProductsByName("Tights").Exists(o => o.ProductId == 853));
            Assert.IsTrue(list.MyProductGetProductsByName("Tights").Exists(o => o.ProductId == 854));

        }

        [TestMethod]
        public void MyListGetProductsByVendorNameTest()
        {
            List<MyProduct> result = list.MyProductGetProductsWithNRecentReviews(2);

            Assert.AreEqual(result[0].Name, "Mountain Bike Socks, M");
            Assert.AreEqual(result[0].ProductId, 709);
            Assert.AreEqual(result[1].Name, "HL Mountain Pedal");
            Assert.AreEqual(result[1].ProductId, 937);
        }

        [TestMethod]
        public void MyListtGetNProductsFromCategoryTest()
        {

            List<MyProduct> result = list.MyListGetNProductsFromCategory("Accessories", 2);
            Assert.AreEqual(result.Count, 2);
            Assert.AreEqual(result[0].Name, "All-Purpose Bike Stand");
            Assert.AreEqual(result[0].ProductId, 879);
            Assert.AreEqual(result[1].Name, "Bike Wash - Dissolver");
            Assert.AreEqual(result[1].ProductId, 877);
        }
    }
}
