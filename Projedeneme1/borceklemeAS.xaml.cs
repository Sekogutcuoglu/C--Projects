using Firebase.Database;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;
using Xamarin.Forms.Xaml;

namespace Projedeneme1
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class borceklemeAS : ContentPage
    {
        static string emailTut;
        FirebaseClient firebaseclient = new FirebaseClient("YourFireBaseClient");
        static kisiselkayıtolgetset veriCekGetSet;
        static string türtut;
        static Color colortut;
        public borceklemeAS ()
		{
			InitializeComponent ();
		}
        protected async override void OnAppearing()
        {
            emailTut = Preferences.Get("email", "null");

            veriCekGetSet = await veriCagırma();
           

        }
        public async Task<bool> update()
        {

            await firebaseclient.Child(nameof(kisiselkayıtolgetset) + "/" + veriCekGetSet.key).PutAsync(JsonConvert.SerializeObject(veriCekGetSet));
            return true;

        }
        public async Task<kisiselkayıtolgetset> veriCagırma()
        {

            return (await firebaseclient.Child(nameof(kisiselkayıtolgetset)).OnceAsync<kisiselkayıtolgetset>()).Where(x => x.Object.email == emailTut).Select(item => new kisiselkayıtolgetset
            {
                key = item.Key,
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
                borclist = item.Object.borclist,



            }).ToList()[0];

        }
     
        private  async void Button_Clicked(object sender, EventArgs e)
        {
            try
            {
                if (verildibtn.IsChecked)
                {
                    türtut = verildibtn.Value.ToString();
                    colortut = Color.LightGreen; ;
                }
                else
                {
                    türtut = alindibtn.Value.ToString();
                    colortut = Color.IndianRed;

                }
                if(isimal.Text==null || paraAl.Text==null || aciklama.Text==null)
                {
                    await DisplayAlert("Hata", "Lütfen kutuları boş bırakmayınız.", "Yeniden dene");

                }
                else
                {
                    veriCekGetSet = await veriCagırma();
                    if (veriCekGetSet.borclist == null)
                    {
                        veriCekGetSet.borclist = new List<kisiler>();
                    }
                    veriCekGetSet.borclist.Add(new kisiler { isimK = isimal.Text, borcmiktar = paraAl.Text, tarih = datepicker.Date.ToShortDateString(), aciklama = aciklama.Text, tur = türtut, color = colortut });

                    var sonuc = await update();

                    await DisplayAlert("Bilgi", "Borç takibi başarılı bir şekilde eklendi.", "Tamam");
                }
               

            }
            catch (Exception)
            {
                await DisplayAlert("Hata", "Beklenmedik bir hata oluştu.", "Yeniden deneyin");


            }

            // refresh_list(sender, e);
        }
    }
}