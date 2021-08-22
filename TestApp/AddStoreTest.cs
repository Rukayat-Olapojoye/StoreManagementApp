using System;
using Moq;
using NUnit.Framework;
using ManagementBL;
using ManagementModels;
using ManagementDataStore;
using System.Threading.Tasks;

namespace TestApp
{
    class AddStoreTest
    {
        private IStoresDatastore storeData;
        public void Setup(Store store)
        {
            var mocktest = new Mock<IStoresDatastore>();
            mocktest.Setup(cusAction => cusAction.WriteStoreToDBAsync(It.IsAny<Store>()))
               .Returns(Task.FromResult(store));
            storeData = mocktest.Object;
        }

        [Test]
        public async Task AddStore()
        {

            var StoreOwner = "636ff51c-5bd0-4199-8842-ac2c4c286ce8";
            var storeID = "c25229ed-9651-4dc7-b27a-2fedd86a7acd";
            var storeName = "DayanMart";
            var products = 120;
            var storetype = "Kiosk";


            Store expected = new Store
            {
                Id = storeID,
                StoreName = storeName,
                customersId = StoreOwner,
                TypeOfStore = (Store.StoreType)Enum.Parse(typeof(Store.StoreType), storetype.ToString()),
                NumofProducts = products

            };


            Setup(expected);
            var actions = new StoreActions(storeData);
            //Act
            var actual = await actions.AddStoreAsync(StoreOwner, storeID, storeName, (Store.StoreType)Enum.Parse(typeof(Store.StoreType),storetype), products);

            //Assert
            Assert.IsNotNull(actual);
            Assert.AreEqual(expected.Id, actual.Id);
            Assert.AreEqual(expected.StoreName, actual.StoreName);
            Assert.AreEqual(expected.customersId, actual.customersId);
            Assert.AreEqual(expected.NumofProducts, actual.NumofProducts);
            Assert.AreEqual(expected.TypeOfStore, actual.TypeOfStore);
            Assert.IsInstanceOf<Store>(actual);
        }
    }
}

