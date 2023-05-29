using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Projedeneme1
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Dovizlerim : ContentPage
    {
        public Dovizlerim()
        {
            InitializeComponent();
            string exchangeRate = "http://www.tcmb.gov.tr/kurlar/today.xml";
            var xmlDoc = new XmlDocument();
            xmlDoc.Load(exchangeRate);

            usdAlis.Text = xmlDoc.SelectSingleNode("Tarih_Date / Currency[@Kod ='USD'] / BanknoteBuying").InnerXml; ;
            usdSatis.Text = xmlDoc.SelectSingleNode("Tarih_Date / Currency[@Kod ='USD'] / BanknoteSelling").InnerXml;

            eurAlis.Text = xmlDoc.SelectSingleNode("Tarih_Date / Currency[@Kod ='EUR'] / BanknoteBuying").InnerXml; ;
            eurSatis.Text = xmlDoc.SelectSingleNode("Tarih_Date / Currency[@Kod ='EUR'] / BanknoteSelling").InnerXml;

            gbpAlis.Text = xmlDoc.SelectSingleNode("Tarih_Date / Currency[@Kod ='GBP'] / BanknoteBuying").InnerXml; ;
            gbpSatis.Text = xmlDoc.SelectSingleNode("Tarih_Date / Currency[@Kod ='GBP'] / BanknoteSelling").InnerXml;

            KWDAlis.Text = xmlDoc.SelectSingleNode("Tarih_Date / Currency[@Kod ='KWD'] / BanknoteBuying").InnerXml; ;
            KWDSatis.Text = xmlDoc.SelectSingleNode("Tarih_Date / Currency[@Kod ='KWD'] / BanknoteSelling").InnerXml;

            JPYAlis.Text = xmlDoc.SelectSingleNode("Tarih_Date / Currency[@Kod ='JPY'] / BanknoteBuying").InnerXml; ;
            JPYSatis.Text = xmlDoc.SelectSingleNode("Tarih_Date / Currency[@Kod ='JPY'] / BanknoteSelling").InnerXml;

            SEKAlis.Text = xmlDoc.SelectSingleNode("Tarih_Date / Currency[@Kod ='SEK'] / BanknoteBuying").InnerXml; ;
            SEKSatis.Text = xmlDoc.SelectSingleNode("Tarih_Date / Currency[@Kod ='SEK'] / BanknoteSelling").InnerXml;




        }
    }
}