using MvvmHelpers;
using MvvmHelpers.Commands;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PriceTrackerMobile.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        public ObservableRangeCollection<string> items { get; }

        public MainPageViewModel()
        {
            IncreaseCount = new Command(OnIncrease);
            CallServerCommand = new AsyncCommand(CallServer);
            items = new ObservableRangeCollection<string>();
            Title = "Main Page";
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
            items.AddRange( new string[] { });
        }
    }
}
