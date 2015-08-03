using Xamarin.Forms;

namespace XamarinTry.Pages
{
    public class TodoItem
    {
        public string Name { get; set; }
        public bool Done { get; set; }
    }

    public class MainPage : TabbedPage
    {
        public MainPage()
        {
            this.Children.Add(new CallPage());
            this.Children.Add(new ListPage());
            this.Children.Add(new OrderPage());

            Padding = new Thickness(20, Device.OnPlatform(40, 20, 20), 20, 20);
        }

       
       
        
    }
}
