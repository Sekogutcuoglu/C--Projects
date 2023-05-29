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
	public partial class sirketgelirgiderkayit : ContentPage
    {
        sirketkayitdatabase havuz = new sirketkayitdatabase();
        internal static sirketkayıtgetset _sirket;


        public sirketgelirgiderkayit ()
		{
			InitializeComponent ();
		}
        internal sirketgelirgiderkayit (sirketkayıtgetset sirket)
        {
            InitializeComponent();
            _sirket = sirket;
        }

        private async void kayitolbutonu_Clicked(object sender, EventArgs e)
        {

            _sirket.hasilat = hasilat.Text;
            _sirket.satislarinmaliyeti = satismaliyeti.Text;
            _sirket.faaliyetgiderleri = faaliyetgiderleri.Text;
            _sirket.yfgelirler = yatirimfaaliyetlerigelir.Text;
            _sirket.yfgiderler = yatirimfaaliyetlerigider.Text;
            _sirket.finansmangelir = finansmangelir.Text;
            _sirket.finansmangider = finansmangider.Text;
            _sirket.vergiler = vergiler.Text;

            var isSaved = await havuz.Save(_sirket);
            if (isSaved)
            {
                await DisplayAlert("BİLGİ", "Kişisel bilgiler kaydedildi LOGIN Ekranına geçiliyor", "TAMAM");
                App.Current.MainPage = new SirketHesabıLoginEkranı();


            }
            else
            {
                await DisplayAlert("ERROR", "HATA", "TAMAM");
            }

        }
    }
}