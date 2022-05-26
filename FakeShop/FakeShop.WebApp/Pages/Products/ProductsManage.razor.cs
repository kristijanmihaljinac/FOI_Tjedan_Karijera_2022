using FakeShop.WebApp.Services.ProductService;
using FakeShop.WebApp.ViewModels;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace FakeShop.WebApp.Pages.Products
{
    public partial class ProductsManage : ComponentBase
    {
        public Product Context { get; set; } = new();

        [Inject]
        protected IProductClientService _productClientService { get; set; }
        [Inject]
        private ISnackbar Snackbar { get; set; }

        [Inject]
        protected IDialogService DialogService { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }


        protected  async Task<bool> OnValidSubmit()
        {
            
            var response = await _productClientService.CreateAsync(Context);

            if (!response.IsSuccessStatusCode)
            {
                Snackbar.Add("Greška prilikom kreiranja proizvoda", Severity.Error);
                return false;
            }
            else
            {
                Snackbar.Add("Proizvod uspješno kreiran", Severity.Success);
            }


            NavigationManager.NavigateTo("products");
         
            return true;
        }

        protected  Task GoBack()
        {
            NavigationManager.NavigateTo("products");

            return Task.CompletedTask;
        }

    }
}
