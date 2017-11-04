using System;

namespace ServiceLayer.Tests.Helpers
{
    public static class MockConstants
    {
        #region CustomerWithoutOrders

        public static string CustomerWithoutOrdersId = "CustomerWithoutOrdersId";

        public static string CustomerWithoutOrdersCompanyName = "CustomerWithoutOrdersCompanyName";

        public static string CustomerWithoutOrdersContactName = "CustomerWithoutOrdersContactName";

        public static string CustomerWithoutOrdersContactTitle = "CustomerWithoutOrdersContactTitle";

        public static string CustomerWithoutOrdersAddress = "CustomerWithoutOrderAddress";

        public static string CustomerWithoutOrdersCity = "CustomerWithoutOrdersCity";

        public static string CustomerWithoutOrdersRegion = "CustomerWithoutOrdersRegion";

        public static string CustomerWithoutOrdersPostalCode = "CustomerWithoutOrdersPostalCode";

        public static string CustomerWithoutOrdersCountry = "CustomerWithoutOrdersCountry";

        public static string CustomerWithoutOrdersPhone = "CustomerWithoutOrdersPhone";

        public static string CustomerWithoutOrdersFax = "CustomerWithoutOrdersFax";

        #endregion

        #region CustomerWithOrders

        public static string CustomerWithOrdersId = "CustomerWithOrdersId";

        public static string CustomerWithOrdersCompanyName = "CustomerWithOrdersCompanyName";

        public static string CustomerWithOrdersContactName = "CustomerWithOrdersContactName";

        public static string CustomerWithOrdersContactTitle = "CustomerWithOrdersContactTitle";

        public static string CustomerWithOrdersAddress = "CustomerWithOrdersAddress";

        public static string CustomerWithOrdersCity = "CustomerWithOrdersCity";

        public static string CustomerWithOrdersRegion = "CustomerWithOrdersRegion";

        public static string CustomerWithOrdersPostalCode = "CustomerWithOrdersPostalCode";

        public static string CustomerWithOrdersCountry = "CustomerWithOrdersCountry";

        public static string CustomerWithOrdersPhone = "CustomerWithOrdersPhone";

        public static string CustomerWithOrdersFax = "CustomerWithOrdersFax";

        #endregion

        #region Order

        public static int OrderId = 1;

        public static DateTime? OrderDate = DateTime.Now;

        public static DateTime? RequiredDate = DateTime.Now.AddDays(5);

        public static DateTime? ShippedDate = DateTime.Now.AddDays(2);

        public static int? ShipVia = 1;

        public static decimal? Freight = 0M;

        public static string ShipName = "Ship Name";

        public static string ShipAddress = "Ship Address";

        public static string ShipCity = "Ship City";

        public static string ShipRegion = "Ship Region";

        public static string ShipPostalCode = "Ship Postal Code";

        public static string ShipCountry = "Ship Country";

        #endregion

        #region Employee

        public static int EmployeeID = 1;

        public static string EmployeeLastName = "LastName";

        public static string EmployeeFirstName = "FirstName";

        public static string EmployeeTitle = "Title";

        public static string EmployeeTitleOfCourtesy = "TitleOfCourtesy";

        public static DateTime? EmployeeBirthDate = null;

        public static DateTime? EmployeeHireDate = null;

        public static string EmployeeAddress = "Address";

        public static string EmployeeCity = "City";

        public static string EmployeeRegion = "Region";

        public static string EmployeePostalCode = "PostalCode";

        public static string EmployeeCountry = "Country";

        public static string EmployeeHomePhone = "HomePhone";

        public static string EmployeeExtension = "Extension";

        public static byte[] EmployeePhoto = new byte[50];

        public static string EmployeeNotes = "Notes";

        public static int? EmployeeReportsTo = null;

        public static string EmployeePhotoPath = "TitleOfCourtesy";

        #endregion

        #region Order Details

        public static int OrderID = OrderId;

        public static int OrderProductID = 1;

        public static decimal OrderUnitPrice = 50M;

        public static short OrderQuantity = 10;

        public static float OrderDiscount = 0F;

        #endregion

        #region Product Details

        public static int ProductID = 1;

        public static string ProductName = "Product Name";

        public static int? ProductSupplierID = null;

        public static int? ProductCategoryID = null;

        public static string ProductQuantityPerUnit = "QuantityPerUnit";

        public static decimal? ProductUnitPrice = 10M;

        public static short? ProductUnitsInStock = 5;

        public static short? ProductUnitsOnOrder = 6;

        public static short? ProductReorderLevel = 1;

        public static bool ProductDiscontinued = false;

        #endregion
    }
}