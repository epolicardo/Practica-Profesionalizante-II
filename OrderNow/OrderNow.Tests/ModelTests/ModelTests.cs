using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace OrderNow.Tests.ModelTests
{
    public  class ModelTests
    {
        [Fact]
        public void Products_Test()
        {
			Products model = new Products() { }; GenericAssertion.ModelTestAssertion(model);
        }


		public static class GenericAssertion
		{
			public static void ModelTestAssertion(object model)
			{
				Type t = model.GetType();
				PropertyInfo[] pi = t.GetProperties();
				foreach (PropertyInfo p in pi)
				{
					System.Console.WriteLine(p.Name + " : " + p.GetValue(model));
				}
				var str = model.ToString();
				Assert.NotNull(model);
			}
		}
	}
}
