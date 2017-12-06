using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace OkaneHoshii.ViewModels
{
    class MainWindowViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        private int _Count = 0;
        public int Count
        {
            get => _Count;
            set
            {
                _Count = value;
                NotifyPropertyChanged();
            }
        }
        public bool IsCounting { get; set; } = false;
        private string _Log = "";
        public string Log
        {
            get => _Log;
            set {
                _Log = value;
                NotifyPropertyChanged();
            }
        }
        public DelegateCommand StartCommand { get; private set; }
        public DelegateCommand StopCommand { get; private set; }
        public DelegateCommand ResetCounterCommand { get; private set; }

        public MainWindowViewModel()
        {
            StartCommand = new DelegateCommand( StartCounting, () => !IsCounting );
            StopCommand = new DelegateCommand( StopCounting, () => IsCounting );
            ResetCounterCommand = new DelegateCommand( ResetCounter, () => true );
        }

        private async Task StartCounting()
        {
            IsCounting = true;
            while(IsCounting == true)
            {
                await Task.Delay(50);
                Log = Log.Insert(0, $"Line { Count++ }{ Environment.NewLine }");
            }
        }

        private async Task StopCounting()
        {
            IsCounting = false;
        }

        private async Task ResetCounter()
        {
            Count = 0;
        }

    }
}
