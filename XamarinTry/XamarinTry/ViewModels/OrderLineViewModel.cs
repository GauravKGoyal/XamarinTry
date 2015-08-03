using System.ComponentModel;
using System.Runtime.CompilerServices;
using XamarinTry.Annotations;

namespace XamarinTry.ViewModels
{
    public class OrderLineViewModel : INotifyPropertyChanged
    {
        private double _Price;
        private double _Quantity;
        private string _Name;
        private bool _Done;

        public bool Done
        {
            get { return _Done;  }
            set { _Done = value;  }
        }


        public string Name
        {
            get { return _Name; }
            set
            {
                _Name = value;
                OnPropertyChanged();
            }
        }

        public double Quantity
        {
            get { return _Quantity; }
            set
            {
                _Quantity = value;
                OnPropertyChanged();
            }
        }

        public double Price
        {
            get { return _Price; }
            set
            {
                _Price = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}