using MudBlazor;
using System.Net.Http.Json;

namespace FakeShop.WebApp.Base.EntityClientService
{
    public abstract class EntityClientService<TModel> : IEntityClientService<TModel>
         where TModel : class
    {
        //TO DO: dohvatit base path iz enviromenta(BASE_PATH = "api") 
        protected readonly string BASE_PATH = "";

        private readonly HttpClient _httpClient;

        private readonly string _path;

        public EntityClientService(HttpClient http, string entityPath)
        {
            _httpClient = http;
            _path = entityPath;
        }

        protected HttpClient Http => _httpClient;

        protected string Path => _path;


        public async Task<ICollection<TModel>> GetAllAsync()
        {
          
            return await Http.GetFromJsonAsync<ICollection<TModel>>($"{Path}").ConfigureAwait(false);
        }

        public async Task<TModel> GetAsync(int id)
        {
            return await Http.GetFromJsonAsync<TModel>($"{Path}/{id}");
        }

        public virtual async Task<GridData<TModel>> GetAllGridDataAsync(string options = "")
        {
            if (!options.Contains("orderby"))
            {
                options += "&$orderby = id desc";
            }

            return await Http.GetFromJsonAsync<GridData<TModel>>($"{BASE_PATH}/{Path}/GetGrid?{options}").ConfigureAwait(false);
        }

        public async Task<HttpResponseMessage> CreateAsync(TModel data)
        {
            return await Http.PostAsJsonAsync<TModel>($"{BASE_PATH}/{Path}", data).ConfigureAwait(false);
        }

        public async Task<HttpResponseMessage> UpdateAsync(int id, TModel data)
        {
            return await Http.PutAsJsonAsync<TModel>($"{BASE_PATH}/{Path}/{id}", data);
        }

        public async Task<HttpResponseMessage> DeleteAsync(int id)
        {
            return await Http.DeleteAsync($"{BASE_PATH}/{Path}/{id}").ConfigureAwait(false);
        }

        public async Task<HttpResponseMessage> Validate(TModel model)
        {
            return await Http.PostAsJsonAsync<TModel>($"{BASE_PATH}/{Path}/Validate", model).ConfigureAwait(false);
        }
    }
}
