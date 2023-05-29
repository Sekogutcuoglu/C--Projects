using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Firebase.Database;
using Xamarin.Forms.Xaml;
using System.Runtime.CompilerServices;

namespace Projedeneme1
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class KullaniciNavigasyonAnasayfasi : FlyoutPage
    {
       
        public KullaniciNavigasyonAnasayfasi()
        {
            InitializeComponent();
            kisiselflyout.kisiselflylist.ItemSelected += OnSelectedItem;
        }
        public KullaniciNavigasyonAnasayfasi(string email)
        {
            Preferences.Set("email", email);

            InitializeComponent();
            kisiselflyout.kisiselflylist.ItemSelected += OnSelectedItem;
        }
      
     
        private void OnSelectedItem(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as NavigasyonOzellik;
            if (item != null)
            {
                if (item.Title == "LogOut")
                {
                    App.Current.MainPage = new MainPage();
                    return;
                }
                Detail = new NavigationPage((Page)Activator.CreateInstance(item.TargetPage));
                kisiselflyout.kisiselflylist.SelectedItem = item;
                IsPresented = false;
            }
        }

    }
}