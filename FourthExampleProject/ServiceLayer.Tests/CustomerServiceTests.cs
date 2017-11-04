namespace ServiceLayer.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Interfaces;
    using Moq;
    using DataLayer.Interfaces;
    using Helpers;
    using ServiceLayer;

    [TestClass]
    public class CustomerServiceTests
    {
        private Mock<IData> dataLayerMock;
        private ICustomerService customerService;
        private DataLayerMockHelper mockHelper;

        [TestInitialize]
        public void SetUp()
        {
            this.mockHelper = new DataLayerMockHelper();

            this.dataLayerMock = this.mockHelper.SetupTicTacToeDataMock();

            this.customerService = new CustomerService(dataLayerMock.Object);
        }
    }
}