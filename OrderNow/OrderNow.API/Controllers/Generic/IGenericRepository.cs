namespace OrderNow.API.Controllers.Generic
{
    public interface IGenericRepository<T> where T : class
    {
        List<T> GetListAsync();
        
        T GetByIdAsync(int Id);
        bool ExistsId(int Id);

        


    }
}
