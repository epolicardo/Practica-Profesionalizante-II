using System.Reflection;

namespace OrderNow.Tests.ModelTests
{
    public class Model_Tests
    {
        [Fact]
        public void Products_Test()
        {
            Products model = new Products() { }; GenericAssertion.ModelTestAssertion(model);
        }

        [Fact]
        public void Address_Test()
        {
            Addresses model = new Addresses() { }; GenericAssertion.ModelTestAssertion(model);
        }

        [Fact]
        public void Categories_Test()
        {
            Categories model = new Categories() { }; GenericAssertion.ModelTestAssertion(model);
        }

       

        [Fact]
        public void Groups_Test()
        {
            Groups model = new Groups() { }; GenericAssertion.ModelTestAssertion(model);
        }

   
        [Fact]
        public void PaymentMethods_Test()
        {
            PaymentMethods model = new PaymentMethods() { }; GenericAssertion.ModelTestAssertion(model);
        }

        [Fact]
        public void People_Test()
        {
            People model = new People() { }; GenericAssertion.ModelTestAssertion(model);
        }

        [Fact]
        public void PublicityContract_Test()
        {
            AdvertisingContracts model = new AdvertisingContracts() { }; GenericAssertion.ModelTestAssertion(model);
        }

        [Fact]
        public void Sales_Test()
        {
            Sales model = new Sales() { }; GenericAssertion.ModelTestAssertion(model);
        }
        [Fact]
        public void SalesDetails_Test()
        {
            SaleDetails model = new SaleDetails() { }; GenericAssertion.ModelTestAssertion(model);
        }
        [Fact]
        public void Users_Test()
        {
            Users model = new Users() { }; GenericAssertion.ModelTestAssertion(model);
        }

        public static class GenericAssertion
        {
            public static void ModelTestAssertion(object model)
            {
                Type t = model.GetType();
                PropertyInfo[] pi = t.GetProperties();
                foreach (PropertyInfo p in pi)
                {
                    Console.WriteLine(p.Name + " : " + p.GetValue(model));
                }
                var str = model.ToString();
                Assert.NotNull(model);
            }
        }
    }
}
