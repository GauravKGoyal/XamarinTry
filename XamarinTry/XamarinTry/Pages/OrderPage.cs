using Xamarin.Forms;
using XamarinTry.ViewModels;

namespace XamarinTry.Pages
{
    public class OrderPage : ContentPage
    {
        private OrderViewModel _orderViewModel;

        public OrderPage()
        {
            Title = "Order";
            _orderViewModel = new OrderViewModel();

            var addButton = new Button() {Text = "Add"};
            addButton.Clicked += addButton_Clicked;

            var orderLineListView = new ListView
            {
                ItemsSource = _orderViewModel.OrderLineCollection,
                ItemTemplate = new DataTemplate(typeof(OrderLineViewCell))
            };
            //listView.ItemTemplate.SetBinding(TextCell.TextProperty, "Name");

            var totalQuantity = new Entry();
            totalQuantity.HorizontalOptions = LayoutOptions.FillAndExpand;
            totalQuantity.BindingContext = _orderViewModel;
            totalQuantity.SetBinding(Entry.TextProperty, "TotalQuantity");

            var totalPrice = new Entry();
            totalPrice.HorizontalOptions = LayoutOptions.FillAndExpand;
            totalPrice.BindingContext = _orderViewModel;
            totalPrice.SetBinding(Entry.TextProperty, "TotalPrice");

            
            var orderLineLayout = new StackLayout()
            {
                Orientation = StackOrientation.Horizontal,
                Children = {totalQuantity, totalPrice}
            };

            var pageLayout = new StackLayout()
            {
                Children = {addButton, orderLineListView, orderLineLayout}
            };

            Content = pageLayout;
        }

        void addButton_Clicked(object sender, System.EventArgs e)
        {
            _orderViewModel.OrderLineCollection.Add(new OrderLineViewModel() {Name = "New Order line", Quantity = 2, Price = 4});
        }

        public class OrderLineViewCell : ViewCell
        {
            public OrderLineViewCell()
            {
                var name = new Entry() { HorizontalOptions = LayoutOptions.FillAndExpand };               
                name.SetBinding(Entry.TextProperty, "Name");

                var quantity = new Entry() { HorizontalOptions = LayoutOptions.FillAndExpand };
                quantity.SetBinding(Entry.TextProperty, "Quantity");

                var price = new Entry() { HorizontalOptions = LayoutOptions.FillAndExpand };
                price.SetBinding(Entry.TextProperty, "Price");

                var layout = new StackLayout()
                {
                    HorizontalOptions = LayoutOptions.StartAndExpand,
                    Orientation = StackOrientation.Horizontal,
                    Children = { name, quantity, price }
                };

                View = layout;
            } 
        }
    }
}
