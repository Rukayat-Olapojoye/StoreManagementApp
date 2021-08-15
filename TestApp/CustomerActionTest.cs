using NUnit.Framework;
using Moq;
using ManagementBL;
using ManagementModels;
using ManagementDataStore;
using System.Threading.Tasks;


namespace TestApp
{
    public class CustomerActionTest
    {
        private ICustomerDatastore customerData;
        public void Setup(bool val)
        {
            var mocktest = new Mock<ICustomerDatastore>();
            mocktest.Setup(cusAction => cusAction.WriteCustomerToDBAsync(It.IsAny<Customer>())).Returns(Task.FromResult(val));
            customerData = mocktest.Object;
        }
        [Test]
        public async Task AddCustomerTest()
        {

            Setup(true);
            var actions = new CustomerActions(customerData);



            var CustomerID = "CUS-8298248998";
            var CustomerfirstName = "Fatimah";
            var CustomerlastName = "Adams";
            var Customeremail = "fati@gmail.com";
            var Customerpassword = "fati@123";
            var Confirmpassword = "fati@123";

            var expected = new Customer
            {
                CustomerID = CustomerID,
                CustomerFirstName = CustomerfirstName,
                CustomerLastName = CustomerlastName,
                CustomerEmail = Customeremail,
                CustomerPassword = Customerpassword,
                ConfirmPassword = Confirmpassword
            };


            //Act
            var actual = await actions.RegistrationAsync(CustomerID, CustomerfirstName, CustomerlastName, Customeremail, Customerpassword, ConcurrentExclusiveSchedulerPair);

            //Assert
            Assert.IsNotNull(actual);
            Assert.AreEqual(expected.CustomerID, actual.CustomerID);
            Assert.AreEqual(expected.CustomerFirstName, actual.CustomerFirstName);
            Assert.AreEqual(expected.CustomerLastName, actual.CustomerLastName);
            Assert.AreEqual(expected.CustomerEmail, actual.CustomerEmail);
            Assert.AreEqual(expected.CustomerPassword, actual.CustomerPassword);
            Assert.AreEqual(expected.ConfirmPassword, actual.ConfirmPassword);
            Assert.IsInstanceOf<Customer>(actual);
        }
    }
}