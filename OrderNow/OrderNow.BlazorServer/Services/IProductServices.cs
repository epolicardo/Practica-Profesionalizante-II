using OrderNow.BlazorServer.Services;

using OrderNow.Common.Data.Entities;

namespace OrderNow.BlazorServer.Services
{
    public interface IProductServices : IGenericServices<Products>
    {

        Task<Products> GetByIdAsync(string Id);

    }
}
