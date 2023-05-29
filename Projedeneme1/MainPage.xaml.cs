using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Projedeneme1
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            
        }


        private void Button_Clicked(object sender, EventArgs e)
        {
         Navigation.PushAsync(new KisiselLoginEkranı());


        }

        private void isyerihesabıbutonu(object sender, EventArgs e)
        {
            Navigation.PushAsync(new SirketHesabıLoginEkranı());
            
        }
    }
}
