using Firebase.Database;
using Newtonsoft.Json;
using System;
using System.Collections;
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
    public partial class borcekle : ContentPage
    {
        
        static string emailTut;
        FirebaseClient firebaseclient = new FirebaseClient("YourFireBaseClient");
        static kisiselkayıtolgetset veriCekGetSet;
        public borcekle()
        {
            InitializeComponent();
        }
        protected async override void OnAppearing()
        {
            emailTut = Preferences.Get("email", "null");

            veriCekGetSet = await veriCagırma();
            if (veriCekGetSet.borclist == null)
            {
                veriCekGetSet.borclist = new List<kisiler>();
            }
            lsview.ItemsSource = veriCekGetSet.borclist;
           

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
        public async Task<bool> update()
        {

            await firebaseclient.Child(nameof(kisiselkayıtolgetset) + "/" + veriCekGetSet.key).PutAsync(JsonConvert.SerializeObject(veriCekGetSet));
            return true;

        }
        private async void refresh_list(object sender, EventArgs e)
        {

            lsview.ItemsSource = null;

            veriCekGetSet = await veriCagırma();
            if (veriCekGetSet.borclist == null)
            {
                veriCekGetSet.borclist = new List<kisiler>();
            }
            lsview.ItemsSource = veriCekGetSet.borclist;


            lsview.EndRefresh();

        }
       

        private async void  deleteButton_Clicked(object sender, EventArgs e)
        {
            var delete = sender as ImageButton;
            var borc = delete.CommandParameter as kisiler;
            veriCekGetSet.borclist.Remove(borc);

            var sonuc = await update();
            refresh_list(sender, e);

        }

        private async void ImageButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new borceklemeAS());

        }
    }
}