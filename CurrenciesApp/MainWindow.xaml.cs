using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Newtonsoft.Json;
using System.Net;
using System.IO;
using CurrenciesApp.Models;

namespace CurrenciesApp
{
    public partial class MainWindow : Window
    {
        private string _url = "https://nationalbank.kz/rss/rates_all.xml?switch=russian";
        public MainWindow()
        {
            InitializeComponent();
        }

        private void findButtonClick(object sender, RoutedEventArgs e)
        {
            WebClient client = new WebClient();

            string xml = "";

            using (Stream stream = client.OpenRead(new Uri(_url)))
            {
                using (var reader = new StreamReader(stream))
                {
                    string line = "";
                    while ((line = reader.ReadLine()) != null)
                    {
                        xml += line;
                    }
                }
            }

            var valuteData = Deserialize<ValuteData>(xml);

            List<ValuteService> valueServices = new List<ValuteService>();

            foreach (var item in valuteData.Channel.Item)
            {
                var valute = new ValuteService { Title = item.Title, Change = item.Change, Description = item.Description };
                if (item.Index == "UP")
                {
                    valute.Index = MaterialDesignThemes.Wpf.PackIconKind.KeyboardArrowUp;
                    
                }
                else if (item.Index == "DOWN")
                {
                    valute.Index = MaterialDesignThemes.Wpf.PackIconKind.KeyboardArrowDown;
                }
                else
                {
                    valute.Index = MaterialDesignThemes.Wpf.PackIconKind.Remove;
                }
                valueServices.Add(valute);
            }

            dataGrid.ItemsSource = valueServices;
            
        }

        private T Deserialize<T>(string input) where T : class
        {
            System.Xml.Serialization.XmlSerializer ser = new System.Xml.Serialization.XmlSerializer(typeof(T));

            using (StringReader sr = new StringReader(input))
            {
                return (T)ser.Deserialize(sr);
            }
        }

    }
}
