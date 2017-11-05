namespace WebAPI.Tests.Constants
{
    public static class MockConstants
    {
        public static string CustomerID = "ABCDE";

        #region FirstCustomerGridModel

        public static string FirstCustomerGridModelID = "ABCDE";

        public static string FirstCustomerGridModelName = "CUSTOMER NAME";

        public static int FirstCustomerGridModelOrdersCount = 0;

        #endregion

        #region SecondCustomerGridModel

        public static string SecondCustomerGridModelID = "QWERT";

        public static string SecondCustomerGridModelName = "SECOND CUSTOMER NAME";

        public static int SecondCustomerGridModelOrdersCount = 10;

        #endregion

        #region CustomerDetails

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

        #region FirstOrderDetails

        public static decimal FirstOrderDetailsOrderSum = 100M;

        public static decimal FirstOrderDetailsOrderSumWithFreight = 200M;

        public static int FirstOrderDetailsProductsCount = 50;

        public static bool FirstOrderDetailsPossibleProblem = true;

        #endregion

        #region SecondOrderDetails

        public static decimal SecondOrderDetailsOrderSum = 555M;

        public static decimal SecondOrderDetailsOrderSumWithFreight = 1005M;

        public static int SecondOrderDetailsProductsCount = 122;

        public static bool SecondOrderDetailsPossibleProblem = false;

        #endregion
    }
}