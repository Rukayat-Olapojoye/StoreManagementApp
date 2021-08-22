using System;
using NUnit.Framework;
using Moq;
using System.Threading.Tasks;
using ManagementModels;
using ManagementDataStore;
using ManagementBL;

namespace TestApp
{
    class RemoveProductTest
    {
        private IStoresDatastore storeData;
        public void Setup(string storeId, int items, string owner)
        {
            var mocktest = new Mock<IStoresDatastore>();

            mocktest.Setup(storeAction => storeAction.RemoveProductsFromStoreAsync(storeId, items, owner))
               .Returns(Task.FromResult(true));
            storeData = mocktest.Object;
        }

        [Test]
        public void RemoveProductFromStore_isSuccsesful()
        {
            string StoreOwner = "c25229ed-9651-4dc7-b27a-2fedd86a7acd";
            string storeID = "77e0b581-f9ec-493f-8f47-6448652496d2";
            int products = 50;

            //arrange
            Setup(storeID, products, StoreOwner);
            StoreActions actions = new StoreActions(storeData);

            //Act
            var expected = actions.RemoveProducts(storeID, products, StoreOwner);

            //Assert
            Assert.IsTrue(expected);

        }
    }
}
