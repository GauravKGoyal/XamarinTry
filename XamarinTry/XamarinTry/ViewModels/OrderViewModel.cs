using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using XamarinTry.Annotations;
using XamarinTry.Helpers;

namespace XamarinTry.ViewModels
{
    public class OrderViewModel : INotifyPropertyChanged
    {
        public ObservableCollectionEx<OrderLineViewModel> OrderLineCollection { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public OrderViewModel()
        {
            OrderLineCollection = new ObservableCollectionEx<OrderLineViewModel>();
            OrderLineCollection.CollectionChanged += OrderLineCollection_CollectionChanged;
            OrderLineCollection.ItemPropertyChanged += OrderLineCollection_ItemPropertyChanged;
        }

        void OrderLineCollection_ItemPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            OnPropertyChanged("TotalQuantity");
            OnPropertyChanged("TotalPrice");
        }

        void OrderLineCollection_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            OnPropertyChanged("TotalQuantity");
            OnPropertyChanged("TotalPrice");
        }

        public double TotalQuantity
        {
            get
            {
                var retValue = OrderLineCollection.Aggregate(0.0, (sum, orderLineItem) => sum += orderLineItem.Quantity);
                return retValue;
            }
        }

        public double TotalPrice
        {
            get
            {
                return OrderLineCollection.Aggregate(0.0, (sum, orderLineItem) => sum += orderLineItem.Price);
            }
        }

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
