using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace SimpleMVVM.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        private int _CountClicks;
        public int CountClicks
        {
            get 
            { 
                return _CountClicks; 
            } 
            set 
            { 
                _CountClicks = value; 
                OnPropertyChanged();
            }
        }
        public MainViewModel()
        {
            Task.Factory.StartNew(() => 
            { 
                while (true)
                {
                    Task.Delay(1000).Wait();
                    CountClicks++;
                }
            });
        }
    }
}