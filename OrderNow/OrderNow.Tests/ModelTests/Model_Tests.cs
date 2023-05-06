using System.Reflection;

namespace OrderNow.Tests.ModelTests
{
    public class Model_Tests
    {
        [Fact]
        public void Products_Test()
        {
            Product model = new Product() { }; GenericAssertion.ModelTestAssertion(model);
        }

        [Fact]
        public void Address_Test()
        {
            Address model = new Address() { }; GenericAssertion.ModelTestAssertion(model);
        }

        [Fact]
        public void Categories_Test()
        {
            Category model = new Category() { }; GenericAssertion.ModelTestAssertion(model);
        }

        [Fact]
        public void Groups_Test()
        {
            Group model = new Group() { }; GenericAssertion.ModelTestAssertion(model);
        }

        [Fact]
        public void PaymentMethods_Test()
        {
            PaymentMethod model = new PaymentMethod() { }; GenericAssertion.ModelTestAssertion(model);
        }

        [Fact]
        public void People_Test()
        {
            Person model = new Person() { }; GenericAssertion.ModelTestAssertion(model);
        }

        [Fact]
        public void PublicityContract_Test()
        {
            AdvertisingContract model = new AdvertisingContract() { }; GenericAssertion.ModelTestAssertion(model);
        }

        [Fact]
        public void Sales_Test()
        {
            Sale model = new Sale() { }; GenericAssertion.ModelTestAssertion(model);
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