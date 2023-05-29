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
    public partial class SirketNavigasyonAnasayfasi : FlyoutPage
    {
        public SirketNavigasyonAnasayfasi(string email)
        {
            Preferences.Set("email", email);

            InitializeComponent();
            Sirketflyout.Sirketflylist.ItemSelected += OnSelectedItem;

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
                Sirketflyout.Sirketflylist.SelectedItem = item;
                IsPresented = false;
            }
        }

    }
}