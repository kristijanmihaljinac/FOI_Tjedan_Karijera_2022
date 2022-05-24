using FakeShop.WebApp.Base.EntityClientService;
using FakeShop.WebApp.ViewModels;

namespace FakeShop.WebApp.Services.ProductService
{
    public class ProductClientService :
        EntityClientService<Product>,
        IProductClientService
    {
        private const string PATH = "products";
        public ProductClientService(HttpClient http) : base(http, PATH)
        {
        }
    }
}
