using Microcharts.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microcharts;
using SkiaSharp;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SkiaSharp.Views.Forms;
using Firebase.Database;
using Xamarin.Essentials;

namespace Projedeneme1
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SirketHesapAnasayfası : ContentPage
    {
        FirebaseClient firebaseclient = new FirebaseClient("YourFireBaseClient");

        static sirketkayıtgetset veriCekGetSet;
        static string emailTut;

        //List<Entry> entries =new List<Entry>()
        //{
        //    new Entry(50)
        //    {
        //        Label = "windows",
        //        ValueLabel="12", 
        //    },
        //    new Entry(30)
        //    {
        //        Label = "windows",
        //        ValueLabel="12",
        //    }
        //};

        public SirketHesapAnasayfası()
        {
            InitializeComponent();
            
        }

        internal async Task<sirketkayıtgetset> veriCagırma()
        {

            return (await firebaseclient.Child(nameof(sirketkayıtgetset)).OnceAsync<sirketkayıtgetset>()).Where(x => x.Object.emailsirket == emailTut).Select(item => new sirketkayıtgetset
            {   
               key = item.Key,
               sirketisim = item.Object.sirketisim,
               emailsirket = item.Object.emailsirket,
               sifresirket = item.Object.sifresirket,
               hasilat = item.Object.hasilat,
               satislarinmaliyeti = item.Object.satislarinmaliyeti,
               faaliyetgiderleri = item.Object.faaliyetgiderleri,
               yfgelirler = item.Object.yfgelirler,
               yfgiderler = item.Object.yfgiderler,
               finansmangelir = item.Object.finansmangelir,
               finansmangider = item.Object.finansmangider,
               vergiler = item.Object.vergiler,
             
            }).ToList()[0];

        }
        protected async override void OnAppearing()
        {
            emailTut = Preferences.Get("email", "null");

            veriCekGetSet = await veriCagırma();
            Preferences.Set("key", veriCekGetSet.key);
            barcharts.Chart = new BarChart()
            {
                PointMode = PointMode.None,
                PointSize = 20,
                MinValue = 0,
                MaxValue = 1000,
                Margin = 10,
                
                Entries = deneme(),
            };
        }
        internal static ChartEntry[] deneme()
        {
            ChartEntry[] entries = new[]
            {
                new ChartEntry(50)
                {
                    Color =SKColor.Parse("#66FF66"),
                 
                },
                new ChartEntry(150)
                {
                     Color =SKColor.Parse("#00CCFF")
                },
                new ChartEntry(110)
                {
                    Color =SKColor.Parse("#CC6666")
                },
                new ChartEntry(150)
                {
                    Color =SKColor.Parse("#FFFFCC")
                },
                new ChartEntry(110)
                {
                    Color =SKColor.Parse("#CC33FF")
                },
                new ChartEntry(110)
                {Color = SKColor.Parse("#000033")},
                new ChartEntry(150)
                {Color = SKColor.Parse("#0066CC")},
                new ChartEntry(110)
                 {Color = SKColor.Parse("#666600")},
            };
        
            return entries;

        }

    }
}