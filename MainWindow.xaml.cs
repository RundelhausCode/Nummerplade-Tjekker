using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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

namespace Nummerplade_Tjekker
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private const string URL = @"https://v1.motorapi.dk/vehicles/";
        private string para = string.Empty;
        public MainWindow()
        {
            InitializeComponent();
            var search = new SearchWindow();
            bool? dialogResult = search.ShowDialog();
            switch (dialogResult)
            {
                case true:

                    break;
                case false:
                case null:
                default:
                    Application.Current.Shutdown();
                    break;
            }


        }
        private void APICall()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(URL);
            client.DefaultRequestHeaders
            
        }
    }
}
