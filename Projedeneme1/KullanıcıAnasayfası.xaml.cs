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
    public partial class KullanıcıAnasayfası : ContentPage
    {
        FirebaseClient firebaseclient = new FirebaseClient("YourFireBaseClient");

        static kisiselkayıtolgetset veriCekGetSet;
        static string emailTut;
        static int intNetgelir ;
        static int intevgider ;
        static int intMutfakgider ;
        static int intKisiselgider;
        static int intAlisverisgider;
        static int intBorcgider;
        static int intdigergider;
        static int intaracgider;
        static int kalan;
        static int toplamGider;

        static double kalanyüzdef;
        static double EvGideryüzdef;
        static double MutfakGideryüzdef;
        static double alisverisyüzdef;
        static double kisiselyüzdef;
        static double borcyüzdef;
        static double digeryüzdef;
        static double aracyüzdef;


        public KullanıcıAnasayfası()
        {

            InitializeComponent();

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

            }).ToList()[0];

        }
      
        protected async override void OnAppearing()
        {
            emailTut = Preferences.Get("email", "null");

            veriCekGetSet = await veriCagırma();
            Preferences.Set("key", veriCekGetSet.key);
          

            intNetgelir = Convert.ToInt32(veriCekGetSet.netgelir, System.Globalization.CultureInfo.CurrentCulture.NumberFormat);
            intevgider = Convert.ToInt32(veriCekGetSet.evgider, System.Globalization.CultureInfo.CurrentCulture.NumberFormat);
            intMutfakgider = Convert.ToInt32(veriCekGetSet.mutfakgider, System.Globalization.CultureInfo.CurrentCulture.NumberFormat);
            intKisiselgider = Convert.ToInt32(veriCekGetSet.kisiselgider, System.Globalization.CultureInfo.CurrentCulture.NumberFormat);
            intAlisverisgider = Convert.ToInt32(veriCekGetSet.alisverisgider, System.Globalization.CultureInfo.CurrentCulture.NumberFormat);
            intBorcgider = Convert.ToInt32(veriCekGetSet.borcgider, System.Globalization.CultureInfo.CurrentCulture.NumberFormat);
            intdigergider = Convert.ToInt32(veriCekGetSet.digergider, System.Globalization.CultureInfo.CurrentCulture.NumberFormat);
            intaracgider = Convert.ToInt32(veriCekGetSet.aracgider, System.Globalization.CultureInfo.CurrentCulture.NumberFormat);

            ToplamGelirgöster.Text = veriCekGetSet.netgelir + "₺";

            toplamGider = intevgider + intMutfakgider + intKisiselgider + intAlisverisgider + intBorcgider + intdigergider + intaracgider;
            kalan = intNetgelir - toplamGider;

            if (kalan > 0)
            {
                bakiyeframe.BackgroundColor = Color.Green;
            }
            else
            {
                bakiyeframe.BackgroundColor = Color.Red;

            }

              kalangöster.Text = kalan + "₺";
            EvGiderGöster.Text = veriCekGetSet.evgider + "₺";
            MutfakGiderGöster.Text = veriCekGetSet.mutfakgider + "₺";
            alisverisgöster.Text = veriCekGetSet.alisverisgider + "₺";
            kisiselgöster.Text = veriCekGetSet.kisiselgider + "₺";
            borcgöster.Text = veriCekGetSet.borcgider + "₺";
            digergöster.Text = veriCekGetSet.digergider + "₺";
            aracgöster.Text = veriCekGetSet.aracgider + "₺";

            EvGideryüzdef = Math.Round(((double)(intevgider) / (double)(toplamGider)) * 100,1);
            MutfakGideryüzdef = Math.Round(((double)(intMutfakgider) / (double)(toplamGider)) * 100,1);
            alisverisyüzdef = Math.Round(((double)(intAlisverisgider) / (double)(toplamGider)) * 100, 1);
            kisiselyüzdef = Math.Round(((double)(intKisiselgider) / (double)(toplamGider)) * 100, 1);
            borcyüzdef = Math.Round(((double)(intBorcgider) / (double)(toplamGider)) * 100, 1);
            digeryüzdef = Math.Round(((double)(intdigergider) / (double)(toplamGider)) * 100, 1);
            aracyüzdef = Math.Round(((double)(intaracgider) / (double)(toplamGider)) * 100, 1);

            evgideryüzde.Text = "%" + Convert.ToString(EvGideryüzdef, System.Globalization.CultureInfo.CurrentCulture.NumberFormat);
            mutfakgideryüzde.Text = "%" + Convert.ToString(MutfakGideryüzdef, System.Globalization.CultureInfo.CurrentCulture.NumberFormat);
            alisverisyüzde.Text = "%" + Convert.ToString(alisverisyüzdef, System.Globalization.CultureInfo.CurrentCulture.NumberFormat);
            kisiselyüzde.Text = "%" + Convert.ToString(kisiselyüzdef, System.Globalization.CultureInfo.CurrentCulture.NumberFormat);
            borcyüzde.Text = "%" + Convert.ToString(borcyüzdef, System.Globalization.CultureInfo.CurrentCulture.NumberFormat);
            digeryüzde.Text = "%" + Convert.ToString(digeryüzdef, System.Globalization.CultureInfo.CurrentCulture.NumberFormat);
            arabayüzde.Text = "%" + Convert.ToString(aracyüzdef, System.Globalization.CultureInfo.CurrentCulture.NumberFormat);

            if (intaracgider == 0)
            {
                arabavarmı.IsVisible = false ;
            }
            else
            {
                arabavarmı.IsVisible = true;

            }




            chartViewRadialGauge.Chart = new DonutChart
            {
                Entries = deneme(),
                LabelTextSize = 30,
                HoleRadius = 0.5f,
                BackgroundColor = SKColor.Parse("FFFFFF"),
                LabelMode = LabelMode.None,
                
            };

        }


        public static ChartEntry[] deneme()
        {
           ChartEntry[] entries = new[]
            {
            //new ChartEntry((float)intNetgelir)
            //{
            //    Label = "Net Gelir",
            //    ValueLabel = veriCekGetSet.netgelir,
            //    Color = SKColor.Parse("#ffc125"),
            //    ValueLabelColor = SKColor.Parse("#ffc125")


            //},
            new ChartEntry((float)intevgider)
            {
                Label = "evgider",
                ValueLabel = veriCekGetSet.evgider,
                Color = SKColor.Parse("#ffe1ff"),
                ValueLabelColor = SKColor.Parse("#ffe1ff"),


            },
            new ChartEntry((float)intMutfakgider)
            {
                Label = "Mutfak",
                ValueLabel = veriCekGetSet.mutfakgider,
                Color = SKColor.Parse("#009acd"),
                ValueLabelColor = SKColor.Parse("#009acd")
            },
            new ChartEntry((float)intKisiselgider)
            {
                 Label = "Kişisel Giderler",
                ValueLabel = veriCekGetSet.kisiselgider,
                Color = SKColor.Parse("#cdcd00"),
                ValueLabelColor = SKColor.Parse("#cdcd00")


             },
                new ChartEntry((float)intAlisverisgider)
                {
                Label = "Alış-Veriş",
                ValueLabel = veriCekGetSet.alisverisgider,
                Color = SKColor.Parse("#ee9a00"),
                ValueLabelColor = SKColor.Parse("#ee9a00")
                },
                 new ChartEntry((float)intBorcgider)
                {
                Label = "Borç",
                ValueLabel = veriCekGetSet.borcgider,
                Color = SKColor.Parse("#c1cdc1"),
                ValueLabelColor = SKColor.Parse("#c1cdc1")
                },
                new ChartEntry((float)intdigergider)
                {
                Label = "Diğer",
                ValueLabel = veriCekGetSet.digergider,
                Color = SKColor.Parse("#c0ff3e"),
                ValueLabelColor = SKColor.Parse("#c0ff3e")
                },

                new ChartEntry((float)intaracgider)
                {
                Label = "Araç Gider",
                ValueLabel = veriCekGetSet.aracgider,
                Color = SKColor.Parse("#dc143c"),
                ValueLabelColor = SKColor.Parse("#dc143c")
                },

        };
            return entries;
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
             Navigation.PushAsync(new updatepage());
        }
    }









}

