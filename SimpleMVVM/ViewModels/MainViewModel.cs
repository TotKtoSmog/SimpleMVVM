using SimpleMVVM.Models;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SimpleMVVM.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        public MainViewModel()
        {
            Task.Factory.StartNew(() =>
            {
                while (true)
                {
                    Task.Delay(1000).Wait();
                    AutoClicks++;
                }
            });
            MaxCountClicks = 100;
            MinCountClicks = 0;
        }
        private int _AutoClicks;
        public int AutoClicks
        {
            get 
            { 
                return _AutoClicks; 
            } 
            set 
            {
                _AutoClicks = value; 
                OnPropertyChanged();
            }
        }
        private int _Clicks;
        public int Clicks
        {
            get 
            { 
                return _Clicks; 
            }
            set 
            { 
                _Clicks = value;
                OnPropertyChanged();
            }
        }
        private int _MaxCountClicks;
        public int MaxCountClicks
        {
            get 
            { 
                return _MaxCountClicks; 
            }
            set 
            { 
                _MaxCountClicks = value;
                OnPropertyChanged();
            }
        }
        private int _MinCountClicks;
        public int MinCountClicks
        {
            get
            {
                return _MinCountClicks;
            }
            set
            {
                _MinCountClicks = value;
                OnPropertyChanged();
            }
        }
        private int _ClicksCondition;
        public int ClicksCondition
        {
            get 
            { 
                return _ClicksCondition; 
            }
            set
            {
                _ClicksCondition = value;
                OnPropertyChanged();
            }
        }

        public DelegateCommand ClickAdd
        {
            get
            {
                return new DelegateCommand((obj) => 
                { 
                    Clicks++; 
                });
            }
        }
        public DelegateCommand ClickSub
        {
            get
            {
                return new DelegateCommand((obj) =>
                {
                    Clicks--;
                });
            }
        }
        public DelegateCommand ClickAddByCondition
        {
            get
            {
                return new DelegateCommand((obj) =>
                {
                    ClicksCondition++;
                }, (obj) => ClicksCondition < MaxCountClicks);
            }
        }
        public DelegateCommand ClickSubByCondition
        {
            get
            {
                return new DelegateCommand((obj) =>
                {
                    ClicksCondition--;
                }, (obj) => ClicksCondition > MinCountClicks);
            }
        }
    }
}