using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Projedeneme1
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class KisiselLoginEkranı : ContentPage
    {
        authentication _login = new authentication();
        public KisiselLoginEkranı()
        {
            InitializeComponent();
        }
        private async void KayıtOl(object sender , EventArgs e)
        {
            await  Navigation.PushAsync(new KayıtOlEkranı());
        }
        private async void SifremiUnuttum(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SifremiUnuttum());
        }
        private async void KullanıcıAnasayfasınagit(object sender, EventArgs e)
        {
            try
            {
                string email = emailtxt.Text;
                string password = sifretxt.Text;
                string token = await _login.Login(email, password);
                if (!string.IsNullOrEmpty(token))
                {
                    App.Current.MainPage = new KullaniciNavigasyonAnasayfasi(email);
                }
                else
                {
                    await DisplayAlert("LOG IN", "hata", "ok");
                }
        }
            catch (Exception hata)
            {
                if (hata.Message.Contains("EMAIL_NOT_FOUND"))
                {
                    await DisplayAlert("HATA", "Bu E-Maile kayıtlı bir hesap bulunamamaktadır", "yeniden dene");
    }
                else if (hata.Message.Contains("INVALID_PASSWORD"))
                {
                    await DisplayAlert("HATA", "Geçersiz Şifre", "yeniden dene");
}
            }
        }
    }
}