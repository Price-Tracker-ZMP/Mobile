using Microcharts;
using PriceTrackerMobile.Models;
using PriceTrackerMobile.PriceTrackerMobile.Interfaces;
using SkiaSharp;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;

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

        Game detailedGame;
        public Game DetailedGame
        {
            get => detailedGame;
            set => SetProperty(ref detailedGame, value);
        }

        string[] months = new string[] { "JAN", "FRB", "MAR", "APR", "MAY", "JUN", "JUL", "AUG", "SEP", "OCT", "NOV", "DEC" };
        float[] turnoverData = new float[] { 10, 5, 3.5f, 1.5f, 9, 12, 15, 20, 15, 10, 10, 8 };
        SKColor blueColor = SKColor.Parse("#09C");
        IPriceTrackerApiService apiService;

        public PriceDetailViewModel()
        {
            Title = "Price Detail";
            apiService = DependencyService.Get<IPriceTrackerApiService>();
        }

        public async Task LoadDetails(int gameId)
        {
            DetailedGame = await apiService.GetGameDetails(gameId);
            InitData();
        }

        void InitData()
        {
            List<ChartEntry> turnoverEntries = new List<ChartEntry>();
            int i = 0;
            foreach (float data in turnoverData)
            {
                turnoverEntries.Add(new ChartEntry(data)
                {
                    Color = blueColor,
                    ValueLabel = $"{data}€",
                    Label = months[i]
                });
                i++;
            }

            LineChart = new LineChart
            {
                Entries = turnoverEntries ,
                LabelTextSize = 30f,
                LineSize = 10f,
                LabelOrientation = Orientation.Horizontal,
                ValueLabelOrientation = Orientation.Horizontal
            };
        }
    }
}
