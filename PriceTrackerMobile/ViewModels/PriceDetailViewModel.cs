using Microcharts;
using PriceTrackerMobile.Models;
using PriceTrackerMobile.Interfaces;
using SkiaSharp;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;
using PriceTrackerMobile.Response;
using PriceTrackerMobile.Helpers;
using PriceTrackerMobile.Services.Toast;

namespace PriceTrackerMobile.ViewModels
{
    public class PriceDetailViewModel : ViewModelBase
    {
        LineChart lineChart;
        public LineChart LineChart
        {
            get => lineChart;
            set => SetProperty(ref lineChart, value);
        }

        PriceHistory priceHistory;
        public PriceHistory PriceHistory
        {
            get => priceHistory;
            set => SetProperty(ref priceHistory, value);
        }

        string[] dates = new string[] { };
        float[] prices = new float[] { };
        SKColor blueColor = SKColor.Parse("#09C");
        IPriceTrackerApiService apiService;

        public PriceDetailViewModel()
        {
            Title = "Price History";
            apiService = DependencyService.Get<IPriceTrackerApiService>();
        }

        public async Task LoadDetails(int gameId, string gameName)
        {
            ApiResponse<PriceHistory> response = await apiService.GetGamePriceHistory(gameId);
            
            if (response.status)
            {
                Title = gameName;
                PriceHistory = response.content;
                dates = PriceHistory.dateFinal.ToArrayStringChartDate();
                prices = PriceHistory.priceFinal.ToArrayFloatPrices();
                
                await new SuccessToastService().ShowAsync(response.message);
            }
            else
            {
                await new ErrorToastService().ShowAsync(response.message);
            }
            InitData();
        }

        void InitData()
        {
            List<ChartEntry> entries = new List<ChartEntry>();
            int i = 0;
            foreach (float price in prices)
            {
                entries.Add(new ChartEntry(price)
                {
                    Color = blueColor,
                    ValueLabel = $"{price}PLN",
                    Label = dates[i]
                });
                i++;
            }

            LineChart = new LineChart
            {
                Entries = entries ,
                LabelTextSize = 15f,
                LineSize = 5f,
                LineMode = LineMode.Straight,
                LabelOrientation = Orientation.Horizontal,
                ValueLabelOrientation = Orientation.Horizontal,
            };
        }
    }
}
