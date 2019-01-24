using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie3
{
    public class MyProduct
    {
        int productId;
        string name;
        string productNumber;
        bool makeFlag;
        bool finishedGoodsFlag;
        string color;
        int safetyLockLevel;
        int reorderPoint;
        float standartCost;
        float listPrice;
        string size;
        string sizeUnitMeasureCode;
        string weightUnitMeasureCode;
        string weight;
        int daysToManufacture;
        string productionLine;
        string _class;
        string style;
        int productSubcategoryID;
        int productModeID;
        string sellStartDate;
        string sellEndDate;
        string discountedDate;
        string rowGuid;
        string modifyDate;

        public int ProductId { get => productId; set => productId = value; }
        public string Name { get => name; set => name = value; }
        public string ProductNumber { get => productNumber; set => productNumber = value; }
        public bool MakeFlag { get => makeFlag; set => makeFlag = value; }
        public bool FinishedGoodsFlag { get => finishedGoodsFlag; set => finishedGoodsFlag = value; }
        public string Color { get => color; set => color = value; }
        public int SafetyLockLevel { get => safetyLockLevel; set => safetyLockLevel = value; }
        public int ReorderPoint { get => reorderPoint; set => reorderPoint = value; }
        public float StandartCost { get => standartCost; set => standartCost = value; }
        public float ListPrice { get => listPrice; set => listPrice = value; }
        public string Size { get => size; set => size = value; }
        public string SizeUnitMeasureCode { get => sizeUnitMeasureCode; set => sizeUnitMeasureCode = value; }
        public string WeightUnitMeasureCode { get => weightUnitMeasureCode; set => weightUnitMeasureCode = value; }
        public string Weight { get => weight; set => weight = value; }
        public int DaysToManufacture { get => daysToManufacture; set => daysToManufacture = value; }
        public string ProductionLine { get => productionLine; set => productionLine = value; }
        public string Class { get => _class; set => _class = value; }
        public string Style { get => style; set => style = value; }
        public int ProductSubcategoryID { get => productSubcategoryID; set => productSubcategoryID = value; }
        public int ProductModeID { get => productModeID; set => productModeID = value; }
        public string SellStartDate { get => sellStartDate; set => sellStartDate = value; }
        public string SellEndDate { get => sellEndDate; set => sellEndDate = value; }
        public string DiscountedDate { get => discountedDate; set => discountedDate = value; }
        public string RowGuid { get => rowGuid; set => rowGuid = value; }
        public string ModifyDate { get => modifyDate; set => modifyDate = value; }
    }
}
