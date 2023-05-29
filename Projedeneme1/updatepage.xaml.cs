using Firebase.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Newtonsoft.Json;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;

namespace Projedeneme1
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class updatepage : ContentPage
	{
		static string emailTut;
        FirebaseClient firebaseclient = new FirebaseClient("YourFireBaseClient");
        static kisiselkayıtolgetset veriCekGetSet;
        static string key;
        public updatepage ()
		{
			InitializeComponent ();

		}
        protected async override void OnAppearing()
		{
            emailTut = Preferences.Get("email", "null");
            key = Preferences.Get("key", "null");

            veriCekGetSet = await veriCagırma();

            netgelirup.Text = veriCekGetSet.netgelir;
            evgiderup.Text = veriCekGetSet.evgider;
            mutfakgiderup.Text = veriCekGetSet.mutfakgider;
            alisverisgiderup.Text = veriCekGetSet.alisverisgider;
            kisiselgiderup.Text = veriCekGetSet.kisiselgider;
            borcgiderup.Text = veriCekGetSet.borcgider;
            digerup.Text = veriCekGetSet.digergider;
            arabagiderup.Text = veriCekGetSet.aracgider;
          


        }

        public async Task<kisiselkayıtolgetset> veriCagırma()
        {

            return (await firebaseclient.Child(nameof(kisiselkayıtolgetset)).OnceAsync<kisiselkayıtolgetset>()).Where(x => x.Object.email == emailTut).Select(item => new kisiselkayıtolgetset
            {
                isim = item.Object.isim,
                email = item.Object.email,
                sifre = item.Object.sifre,
                netgelir = item.Object.netgelir,
                evgider = item.Object.evgider,
                mutfakgider = item.Object.mutfakgider,
                kisiselgider = item.Object.kisiselgider,
                alisverisgider = item.Object.alisverisgider,
                borcgider = item.Object.borcgider,
                digergider = item.Object.digergider,
                aracgider = item.Object.aracgider,

            }).ToList()[0];

        }
        public async Task<bool> update(kisiselkayıtolgetset update)
        {

            await firebaseclient.Child(nameof(kisiselkayıtolgetset) + "/" + key).PutAsync(JsonConvert.SerializeObject(update));
            return true;

        }

        private  async void Button_Clicked(object sender, EventArgs e)
        {
            try
            {
                veriCekGetSet.netgelir = netgelirup.Text;
                veriCekGetSet.evgider = evgiderup.Text;
                veriCekGetSet.mutfakgider = mutfakgiderup.Text;
                veriCekGetSet.alisverisgider = alisverisgiderup.Text;
                veriCekGetSet.kisiselgider = kisiselgiderup.Text;
                veriCekGetSet.borcgider = borcgiderup.Text;
                veriCekGetSet.digergider = digerup.Text;
                veriCekGetSet.aracgider = arabagiderup.Text;

                await update(veriCekGetSet);

                await DisplayAlert("Bilgilendirme","Güncelleme işlemi başarılı","Tamam");
            }
            catch (Exception)
            {

                await DisplayAlert("Hata", "Beklenmedik bir hata oluştu. Lütfen bilgileri kontrol ediniz.", "Yeniden Dene");
            }


        }
    }
}