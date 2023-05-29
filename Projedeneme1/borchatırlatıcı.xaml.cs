using Plugin.LocalNotification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plugin.LocalNotification;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;

namespace Projedeneme1
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class borchatırlatıcı : ContentPage
	{
		public borchatırlatıcı ()
		{
			InitializeComponent ();
           
        }
        protected async override void OnAppearing()
        {
            
        }

        private  async void Button_Clicked(object sender, EventArgs e)
        {
            await DisplayAlert("Bilgilendirme", "Hatırlatıcı " + datepicker.Date.ToShortDateString() + " tarihine başarıyla ayarlandı", "Tamam");

            var notification = new NotificationRequest
            {
                
                BadgeNumber = 1,
                Description = isimal.Text+" isimli kişiye "+   " bugün  "+ paraAl.Text+"₺" + " ödeme yapılacak.",
                ReturningData = "Dummy Data",
                NotificationId = 505,
                Title = "Hatırlatıcı",
                Subtitle = "Alarm!!!!!",
                Schedule =
                {
                  NotifyTime =DateTime.ParseExact($"{datepicker.Date.ToShortDateString()} 08:00:00", "MM.dd.yyyy HH:mm:ss",System.Globalization.CultureInfo.InvariantCulture)
                }      
            };
            await LocalNotificationCenter.Current.Show(notification);
            await DisplayAlert("Bilgilendirme", "Hatırlatıcı " + datepicker.Date.ToShortDateString() + " tarihine başarıyla ayarlandı", "Tamam");

        }

    }
}
