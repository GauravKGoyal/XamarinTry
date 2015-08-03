using System;
using Core;
using Xamarin.Forms;

namespace XamarinTry.Pages
{
    public class CallPage : ContentPage
    {
        private Entry _entryPhoneWord;
        private Button _buttonCall, _buttonTranlate;
        private string _phoneNumber;

        public CallPage()
        {
            Title = "Call";

            var stackLayout = new StackLayout()
            {
                Orientation = StackOrientation.Vertical,
                VerticalOptions = LayoutOptions.FillAndExpand,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                Spacing = 10
            };


            stackLayout.Children.Add(new Label() { Text = "Enter a Phoneword:" });
            stackLayout.Children.Add(_entryPhoneWord = new Entry() { Text = "1-855-XAMARIN" });
            stackLayout.Children.Add(_buttonTranlate = new Button() { Text = "Translate" });
            stackLayout.Children.Add(_buttonCall = new Button() { Text = "Call" });

            _buttonTranlate.Clicked += ButtonTranlateClicked;
            _buttonCall.Clicked += ButtonCallClicked;

            Content = stackLayout;
        }

        async void ButtonCallClicked(object sender, EventArgs e)
        {
            var dialNumber = await this.DisplayAlert("Dial a number", "Would you like to call " + _phoneNumber, "Yes", "No");
            if (dialNumber == false)
                return;

            var dialer = DependencyService.Get<IDialer>();
            dialer.Dial(_phoneNumber);
        }

        private void ButtonTranlateClicked(object sender, EventArgs e)
        {
            _phoneNumber = PhonewordTranslator.ToNumber(_entryPhoneWord.Text);
            _buttonCall.Text = "Call " + _phoneNumber;
        }
    }
}
