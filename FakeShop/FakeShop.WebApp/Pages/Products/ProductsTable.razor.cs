﻿using FakeShop.WebApp.Services.ProductService;
using FakeShop.WebApp.ViewModels;
using Microsoft.AspNetCore.Components;

namespace FakeShop.WebApp.Pages.Products
{
    public partial class ProductsTable : ComponentBase
    {

        [Inject]
        protected IProductClientService _productClientService { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }


        private ICollection<Product> _productList = null;

        public bool IsBusy { get => _productList == null; }

        protected override async Task OnInitializedAsync()
        {
            _productList = await _productClientService.GetAllAsync();
            await base.OnInitializedAsync();
        }

        public async Task New()
        {
            NavigationManager.NavigateTo("products/new");
        }
    }



}
