using NUnit.Framework;
using Moq;
using ManagementBL;
using ManagementModels;
using ManagementDataStore;
using System.Threading.Tasks;

namespace TestApp
{
    class UserLoginTest
    {
        private ICustomerDatastore customerData;
        public void Setup(Customer customerlogin)
        {
            var mocktest = new Mock<ICustomerDatastore>();
            mocktest.Setup(cuslogin => cuslogin.ReadCustomerFromDBAsync(It.IsAny<Customer>()))
               .Returns(Task.FromResult(customerlogin));
            customerData = mocktest.Object;
        }

        [Test]
        public async Task LoginCustomer() {

            string email = "dayan@gmail.com";
            string password = "dayan@21";

            var expected = new Customer
            {
                Email = email,
                 Password = password
            };
            //Arrange

            Setup(expected);
            CustomerActions customer = new CustomerActions(customerData);

            

            //Act 
            Customer cus = await customer.LoginAsync(email, password);

            //Assert
            Assert.NotNull(cus);
            Assert.AreEqual(cus.Email, email);
            Assert.AreEqual(cus.Password, password);
        }
    }
}
