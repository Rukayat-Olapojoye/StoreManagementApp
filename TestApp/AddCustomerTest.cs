using NUnit.Framework;
using Moq;
using ManagementBL;
using ManagementModels;
using ManagementDataStore;
using System.Threading.Tasks;


namespace TestApp
{
    public class AddCustomerTest
    {

        private ICustomerDatastore customerData;
        public void Setup(Customer customer)
        {
            var mocktest = new Mock<ICustomerDatastore>();
            mocktest.Setup(cusAction => cusAction.WriteCustomerToDBAsync(It.IsAny<Customer>()))
               .Returns(Task.FromResult(customer));
            customerData = mocktest.Object;
        }
        [Test]
        public async Task AddCustomer()
        {

            var CustomerID = "c25229ed-9651-4dc7-b27a-2fedd86a7acd";
            var CustomerfirstName = "Fatimah";
            var CustomerlastName = "Adams";
            var Customeremail = "fati@gmail.com";
            var Customerpassword = "fati@123";
            var Confirmpassword = "fati@123";


            var expected = new Customer
            {
                Id = CustomerID,
                FirstName = CustomerfirstName,
                LastName = CustomerlastName,
                Email = Customeremail,
                Password = Customerpassword,
                ConfirmPassword = Confirmpassword
            };


            Setup(expected);
            var actions = new CustomerActions(customerData);

            //Act
            var actual = await actions.RegistrationAsync(CustomerID, CustomerfirstName, CustomerlastName, Customeremail, Customerpassword, Confirmpassword);

            //Assert
            Assert.IsNotNull(actual);
            Assert.AreEqual(expected.Id, actual.Id);
            Assert.AreEqual(expected.FirstName, actual.FirstName);
            Assert.AreEqual(expected.LastName, actual.LastName);
            Assert.AreEqual(expected.Email, actual.Email);
            Assert.AreEqual(expected.Password, actual.Password);
            Assert.AreEqual(expected.ConfirmPassword, actual.ConfirmPassword);
            Assert.IsInstanceOf<Customer>(actual);
        }

       

    }
}