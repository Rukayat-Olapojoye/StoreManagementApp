using System;
using NUnit.Framework;
using Moq;
using ManagementBL;
using ManagementModels;
using ManagementDataStore;
using System.Threading.Tasks;

namespace TestApp
{
    class GetNoOfProductsTest
    {
        private IStoresDatastore storeData;
        public void Setup(string storeId, int product)
        {
            var mocktest = new Mock<IStoresDatastore>();

            mocktest.Setup(storeAction => storeAction.GetNumOfStoreproductsAsync(storeId))
               .Returns(Task.FromResult(product));
            storeData = mocktest.Object;
        }

        [Test]
        public void getNumberofstoreProduct_isSuccsesful()
        {

            string storeID = "Sc25229ed-9651-4dc7-b27a-2fedd86a7acd";
            int productFound = 30;


            //arrange
           Setup(storeID, productFound);
            StoreActions actions = new StoreActions(storeData);

            //Act
            var expected = actions.GetNumberofProducts(storeID);

            //Assert
            Assert.Positive(expected);

        }
    }
}
