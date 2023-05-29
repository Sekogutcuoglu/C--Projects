using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Projedeneme1
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SirketHesabıLoginEkranı : ContentPage
    {
        Authenticationsirket _login = new Authenticationsirket();

        public SirketHesabıLoginEkranı()
        {
            InitializeComponent();
        }
        private async void KayıtOl1(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new KayıtOlSirketHesap());

        }

        private async void SifremiUnuttum1(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SiframiUnuttumSirketHesap());

        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            string email = emailtxt.Text;
            string password = sifretxt.Text;
            string token = await _login.Login(email, password);
            if (!string.IsNullOrEmpty(token))
            {
           //   App.Current.MainPage = new KullaniciNavigasyonAnasayfasi(email);
                App.Current.MainPage = new SirketNavigasyonAnasayfasi(email);

            }
            else
            {
                await DisplayAlert("LOG IN", "hata", "ok");
            }

        }
    }
}