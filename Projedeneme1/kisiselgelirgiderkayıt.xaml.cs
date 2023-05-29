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
	public partial class kisiselgelirgiderkayıt : ContentPage
	{
        kisiselkayitoldatabase havuz = new kisiselkayitoldatabase();

        public static kisiselkayıtolgetset _kisisel;
        public kisiselgelirgiderkayıt ()
		{
			InitializeComponent ();
		}
        public kisiselgelirgiderkayıt(kisiselkayıtolgetset kisisel)
        {
            InitializeComponent();
            _kisisel= kisisel;
        }

        private void arabavarmı_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
			if(araba.IsVisible==true)
			{
				araba.IsVisible = false;
			}
			else { araba.IsVisible = true; }
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            _kisisel.netgelir = gelirentry.Text;
            _kisisel.evgider = eventry.Text;
            _kisisel.mutfakgider = mutfakentry.Text;
            _kisisel.alisverisgider = alisverisentry.Text;
            _kisisel.kisiselgider = kisiselentry.Text;
            _kisisel.borcgider = borcentry.Text;
            _kisisel.digergider = borcentry.Text;
            _kisisel.aracgider = arabagider.Text;

            var isSaved = await havuz.Save(_kisisel);
            if (isSaved)
            {
                await DisplayAlert("BİLGİ", "Kişisel bilgiler kaydedildi LOGIN Ekranına geçiliyor", "TAMAM");
                App.Current.MainPage = new KisiselLoginEkranı();


            }
            else
            {
                await DisplayAlert("ERROR", "HATA", "TAMAM");
            }


        }
    }
}