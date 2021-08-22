using System.Threading.Tasks;
using ManagementModels;
using System;
using NUnit.Framework;
using Moq;
using ManagementDataStore;
using ManagementBL;

namespace TestApp
{
    class DeleteStoreTest
    {
        private IStoresDatastore storeData;
        public void Setup(string storeId)
        {
            var mocktest = new Mock<IStoresDatastore>();

            mocktest.Setup(storeAction => storeAction.DeleteStoresAsync(storeId))
               .Returns(Task.FromResult(true));
            storeData = mocktest.Object;
        }

        [Test]
        public void DeleteStore_isSuccsesful()
        {
            
            string storeID = "c25229ed-9651-4dc7-b27a-2fedd86a7acd";
            

            //arrange
            Setup(storeID);
            StoreActions actions = new StoreActions(storeData);

            //Act
            var expected = actions.DeleteStore(storeID).Result;

            //Assert
            Assert.IsTrue(expected);

        }
    }
}
