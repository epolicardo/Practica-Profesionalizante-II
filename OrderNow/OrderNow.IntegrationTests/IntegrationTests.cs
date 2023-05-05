using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Moq;
using OrderNow.Blazor;
using OrderNow.Blazor.Data;
using Repositories;
using Services;

namespace OrderNow.IntegrationTests
{
    public class IntegrationTest
    {
        protected readonly HttpClient _client;
        public readonly BusinessesServices sut;


        public IntegrationTest()
        {
            
           
        }

        public void Prueba()
        {
        }
    }
}