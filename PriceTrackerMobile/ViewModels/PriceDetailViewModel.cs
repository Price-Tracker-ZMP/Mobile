using Microcharts;
using PriceTrackerMobile.Models;
using PriceTrackerMobile.Services;
using SkiaSharp;
using System.Collections.Generic;
using System.Threading.Tasks;

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
        float[] turnoverData = new float[] { 1000, 5000, 3500, 12000, 9000, 15000, 3000, 0, 0, 0, 0, 0 };
        SKColor blueColor = SKColor.Parse("#09C");

        public PriceDetailViewModel()
        {
            Title = "Price Detail";
        }

        public async Task LoadDetails(int gameId)
        {
            DetailedGame = await PriceTrackerApiService.GetGameDetails(gameId);
            InitData();
        }

        void InitData()
        {
            var turnoverEntries = new List<ChartEntry>();
            int i = 0;
            foreach (var data in turnoverData)
            {
                turnoverEntries.Add(new ChartEntry(data)
                {
                    Color = blueColor,
                    ValueLabel = $"{data / 1000} k",
                    Label = months[i]
                });
                i++;
            }

            LineChart = new LineChart { Entries = turnoverEntries, LabelTextSize = 30f, LabelOrientation = Orientation.Horizontal };
        }
    }
}
