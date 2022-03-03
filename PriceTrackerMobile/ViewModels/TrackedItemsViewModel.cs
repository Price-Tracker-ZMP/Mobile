using MvvmHelpers;
using MvvmHelpers.Commands;
using PriceTrackerMobile.Models;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PriceTrackerMobile.ViewModels
{
    public class TrackedItemsViewModel : ViewModelBase
    {
        public ObservableRangeCollection<Item> items { get; }
        public ObservableRangeCollection<Grouping<string, Item>> itemGroups { get; set; }

        public TrackedItemsViewModel()
        {
            IncreaseCount = new Command(OnIncrease);
            CallServerCommand = new AsyncCommand(CallServer);
            items = new ObservableRangeCollection<Item>();
            Title = "Tracked Items";
        }
        public ICommand IncreaseCount { get; }
        public ICommand CallServerCommand { get; }
        int clickCount;
        string countDisplay = "Click me!";
        public string CountDisplay
        {
            get => countDisplay;
            set => SetProperty(ref countDisplay, value);
        }

        void OnIncrease()
        {
            CountDisplay = $"You clicked {++clickCount} time(s)";
        }

        async Task CallServer()
        {
            items.AddRange( new Item[] { });
        }
    }
}
