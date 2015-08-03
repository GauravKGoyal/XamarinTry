using Xamarin.Forms;

namespace XamarinTry.Pages
{
    public class ListPage : ContentPage
    {
        public ListPage()
        {
            Title = "List";
            var stackLayout = new StackLayout();
            var listView = new ListView() {RowHeight = 40};
            listView.ItemsSource = new TodoItem[] {
                new TodoItem {Name = "Buy pears"},
                new TodoItem {Name = "Buy oranges", Done=true},
                new TodoItem {Name = "Buy mangos"},
                new TodoItem {Name = "Buy apples", Done=true},
                new TodoItem {Name = "Buy bananas", Done=true}
            };
            listView.ItemTemplate = new DataTemplate(typeof(TextCell));
            
            listView.ItemTemplate.SetBinding(TextCell.TextProperty, "Name");
            listView.ItemSelected += listView_ItemSelected;

            stackLayout.Children.Add(listView);
            Content = stackLayout;
        }

        void listView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            DisplayAlert("Tapped!", e.SelectedItem + "was tapped", "Ok");
        }

    }
}
