using Data.Entities;

namespace OrderNow.BlazorServer.Services
{
    public interface IProductServices : IGenericServices<Products>
    {

        Task<Products> GetByIdAsync(string Id);

    }
}
