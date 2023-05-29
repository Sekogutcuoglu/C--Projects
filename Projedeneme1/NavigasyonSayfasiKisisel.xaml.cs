using Firebase.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Projedeneme1
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NavigasyonSayfasiKisisel : ContentPage
    {
        static string emailTut;
        FirebaseClient firebaseclient = new FirebaseClient("YourFireBaseClient");
        static kisiselkayıtolgetset veriCekGetSet;
        public NavigasyonSayfasiKisisel()
        {
            InitializeComponent();
        }
        protected async override void OnAppearing()
        {
            emailTut = Preferences.Get("email", "null");

            veriCekGetSet = await veriCagırma();
             isimgöster.Text =   "Hoşgeldin " +   veriCekGetSet.isim.ToUpper();


        }
        public async Task<kisiselkayıtolgetset> veriCagırma()
        {

            return (await firebaseclient.Child(nameof(kisiselkayıtolgetset)).OnceAsync<kisiselkayıtolgetset>()).Where(x => x.Object.email == emailTut).Select(item => new kisiselkayıtolgetset
            {
                isim = item.Object.isim,
              

            }).ToList()[0];

        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            System.Diagnostics.Process.GetCurrentProcess().Kill();
        }
    }
}