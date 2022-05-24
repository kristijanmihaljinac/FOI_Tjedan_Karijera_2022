
using MudBlazor;

namespace FakeShop.WebApp.Base.EntityClientService
{
    public interface IEntityClientService<TModel>
         where TModel : class
    {
        Task<GridData<TModel>> GetAllGridDataAsync(string options = "");

        Task<ICollection<TModel>> GetAllAsync();

        Task<TModel> GetAsync(int id);

        Task<HttpResponseMessage> CreateAsync(TModel data);

        Task<HttpResponseMessage> UpdateAsync(int id, TModel data);

        Task<HttpResponseMessage> DeleteAsync(int id);

    }
}
