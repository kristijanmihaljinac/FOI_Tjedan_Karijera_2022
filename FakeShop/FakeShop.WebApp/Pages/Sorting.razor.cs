using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace FakeShop.WebApp.Pages
{
    public partial class Sorting : ComponentBase
    {

        protected override void OnInitialized()
        {
            base.OnInitialized();
            Generate();
        }

        public List<double> ListToSort { get; set; } = new List<double>();

        private List<ChartSeries> _chartData = new List<ChartSeries>() { new ChartSeries() };
        public List<ChartSeries> ChartData
        {
            get
            {
                _chartData[0].Data = ListToSort.ToArray();
                return _chartData;
            }
        }

        public void Generate()
        {
            Random _rng = new Random();
            ListToSort = new List<double>();
            for (int i = 0; i < 25; i++)
            {
                ListToSort.Add(_rng.Next(0, 100));
            }

            StateHasChanged();
        }

        public async Task Sort()
        {
            ChartData[0].Name = "BubbleSort";
            await BubbleSort(ListToSort);
        }

        public async Task BubbleSort(List<double> arrayToSort)
        {
            bool swapped = true;
            while (swapped)
            {
                swapped = false;
                for (int i = 0; i <= arrayToSort.Count - 2; i++)
                {
                    if (arrayToSort[i] > arrayToSort[i + 1])
                    {
                        double temp = arrayToSort[i + 1];
                        arrayToSort[i + 1] = arrayToSort[i];
                        arrayToSort[i] = temp;

                        await Task.Delay(10);
                        StateHasChanged();

                        swapped = true;
                    }
                }
            }
        }
    }
}


