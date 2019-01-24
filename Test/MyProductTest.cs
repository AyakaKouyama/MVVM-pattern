using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Zadanie3;

namespace Test
{
    [TestClass]
    public class MyProductTest
    {

        [TestMethod]
        public void FillTest()
        {
            using (DataBaseDataContext db = new DataBaseDataContext())
            {
                List<Product> fromDB = db.Product.ToList();
                MyProductList list = new MyProductList();
                list.Fill();

                Assert.AreEqual(fromDB.Count, list.MyProduct.Count);
                for (int i = 0; i < list.MyProduct.Count; i++)
                {
                    Assert.AreEqual(list.MyProduct[i].ProductId, fromDB[i].ProductID);
                    Assert.AreEqual(list.MyProduct[i].Name, fromDB[i].Name);
                    Assert.AreEqual(list.MyProduct[i].ProductNumber, fromDB[i].ProductNumber);
                    Assert.AreEqual(list.MyProduct[i].MakeFlag, fromDB[i].MakeFlag);
                    Assert.AreEqual(list.MyProduct[i].FinishedGoodsFlag, fromDB[i].FinishedGoodsFlag);
                    Assert.AreEqual(list.MyProduct[i].Color, fromDB[i].Color);
                    Assert.AreEqual(list.MyProduct[i].SafetyLockLevel, fromDB[i].SafetyStockLevel);
                    Assert.AreEqual(list.MyProduct[i].ReorderPoint, fromDB[i].ReorderPoint);
                    Assert.AreEqual(list.MyProduct[i].Size, fromDB[i].Size);
                    Assert.AreEqual(list.MyProduct[i].SizeUnitMeasureCode, fromDB[i].SizeUnitMeasureCode);
                    Assert.AreEqual(list.MyProduct[i].WeightUnitMeasureCode, fromDB[i].WeightUnitMeasureCode);
                    Assert.AreEqual(list.MyProduct[i].DaysToManufacture, fromDB[i].DaysToManufacture);
                    Assert.AreEqual(list.MyProduct[i].ProductionLine, fromDB[i].ProductLine);
                    Assert.AreEqual(list.MyProduct[i].Class, fromDB[i].Class);
                    Assert.AreEqual(list.MyProduct[i].Style, fromDB[i].Style);
                }
            }
        }

    }
}
