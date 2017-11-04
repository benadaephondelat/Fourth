namespace ServiceLayer.Tests.Helpers
{
    using DataLayer.Interfaces;

    using Moq;

    public class DataLayerMockHelper
    {
        public Mock<IData> SetupTicTacToeDataMock()
        {
            Mock<IData> dataMock = new Mock<IData>();

            return dataMock;
        }
    }
}