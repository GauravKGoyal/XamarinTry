using Microsoft.Phone.Tasks;
using Xamarin.Forms;
using XamarinTry.WinPhone;

[assembly: Dependency(typeof(Dialer))]
namespace XamarinTry.WinPhone
{    
    class Dialer : IDialer
    {
        public bool Dial(string phoneNumber)
        {
            var phoneCallTask = new PhoneCallTask
            {
                PhoneNumber = phoneNumber,
                DisplayName = "Phoneword"
            };

            phoneCallTask.Show();
            return true;
        }
    }
}
