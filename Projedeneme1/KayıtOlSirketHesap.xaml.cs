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
    public partial class KayıtOlSirketHesap : ContentPage
    {
        sirketkayitdatabase havuz = new sirketkayitdatabase();
        Authenticationsirket _authentication = new Authenticationsirket();
        public KayıtOlSirketHesap()
        {
            InitializeComponent();
        }

        private async void kayitolbutonu_Clicked(object sender, EventArgs e)
        {
            string name = isimkayit.Text;
            string email = emailkayit.Text;
            string sifre = sifrekayit.Text;
            bool ıssave = await _authentication.Register(email, sifre, name);

            sirketkayıtgetset kayitolma = new sirketkayıtgetset();
            kayitolma.sirketisim = name;
            kayitolma.emailsirket = email;
            kayitolma.sifresirket = sifre;
            if (string.IsNullOrEmpty(name))
            { await DisplayAlert("UYARI", "LÜTFEN ADINIZI BOŞ BIRAKMAYINIZ", "CANCEL"); }
            if (string.IsNullOrEmpty(email))
            { await DisplayAlert("UYARI", "LÜTFEN E-MAİL BOŞ BIRAKMAYINIZ", "CANCEL"); }
            if (string.IsNullOrEmpty(sifre))
            { await DisplayAlert("UYARI", "LÜTFEN ŞİFREYİ BOŞ BIRAKMAYINIZ", "CANCEL"); }

            if (ıssave)
            { await DisplayAlert("kayıt başarılı", "kayıt başarılı", "devam"); }
            else
            { await DisplayAlert("HATA", "katıt olurken hata yeniden deneyin", "yeniden dene"); }

            await Navigation.PushAsync(new sirketgelirgiderkayit(kayitolma));

        }
    }
}