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
    public partial class KayıtOlEkranı : ContentPage
    {
        kisiselkayitoldatabase havuz = new kisiselkayitoldatabase();
        authentication _authentication = new authentication();
        public KayıtOlEkranı()
        {
            InitializeComponent();
        }
        private async void Button_Clicked(object sender, EventArgs e)
        {
            try
            {
                string name = isimkayit.Text;
                string email = emailkayit.Text;
                string sifre = sifrekayit.Text;
                bool ıssave = await _authentication.Register(email, sifre, name);
              
                kisiselkayıtolgetset kayitolma = new kisiselkayıtolgetset();
                kayitolma.isim = name;
                kayitolma.email = email;
                kayitolma.sifre = sifre;
                if (string.IsNullOrEmpty(name))
                { await DisplayAlert("UYARI", "LÜTFEN ADINIZI BOŞ BIRAKMAYINIZ", "CANCEL");  }
                if (string.IsNullOrEmpty(email))
                {await DisplayAlert("UYARI", "LÜTFEN E-MAİL BOŞ BIRAKMAYINIZ", "CANCEL");}
                if (string.IsNullOrEmpty(sifre))
                {  await DisplayAlert("UYARI", "LÜTFEN ŞİFREYİ BOŞ BIRAKMAYINIZ", "CANCEL"); }
              
                if (ıssave)
                { await DisplayAlert("kayıt başarılı", "kayıt başarılı", "devam");   }
                else
                {    await DisplayAlert("HATA", "katıt olurken hata yeniden deneyin", "yeniden dene"); }

                await Navigation.PushAsync(new kisiselgelirgiderkayıt(kayitolma));
            }
            catch (Exception exception)
            {
                if (exception.Message.Contains("EMAIL_EXISTS"))
                {
                     await DisplayAlert("HATA", "Bu E-mail daha önce kullanılmış", "yeniden dene");
                }
                else
                {
                    await DisplayAlert("HATA", "Beklenmedik bir hata oluştu", "yeniden dene");

                }
            }
        }
    }
}