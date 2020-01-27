using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
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


namespace Nummerplade_Tjekker
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string para = string.Empty;
        public MainWindow()
        {
            InitializeComponent();
            OpenSearch();
            

        }
        private async void OpenSearch(bool searchFailde = false)
        {
            
            var car = new Car();
            car = null;
            var search = new SearchWindow();
            bool? dialogResult = search.ShowDialog();
            while (car == null)
            {
                if (dialogResult != true) Environment.Exit(1);
                car = await APICall("https://v1.motorapi.dk/vehicles/" + search.vin);
                if (car != null) break;
                var search2 = new SearchWindow();
                search2.errolabel.Visibility = Visibility.Visible;
                dialogResult = search2.ShowDialog();
                
                
                
            }
            SetList(car);

        }

        private void SetList(Car car)
        {
            SPCon.Children.Clear();

            string an = "Nej";


            if (car.coupling)
            {
                an = "Ja";
            }


            MakeTB(new List<string>
            {
                {"registreringsnummer: " + car.registration_number},
                {"status: " + car.status + "den. " + car.status_date.Substring(0,10)},
                {"type: " + car.type },
                {"Brug: " + car.use },
                {"Første Registreringsdato: " + car.first_registration.Substring(0,10)},
                {"stelnummer: " + car.vin},
                {"Egen vægt: " + car.own_weight },
                {"Total vægt: " + car.total_weight},
                {"aksler: " + car.axels },
                {"trækaksler: " + car.pulling_axels },
                {"Sæder: " + car.seats },
                {"anhænger: " + an },
                {"døre: " + car.doors },
                {"producent: " + car.make },
                {"Model: " + car.model },
                {"Variant: " + car.variant },
                {"Model type: " + car.model_type },
                {"Model år: " + car.model_year },
                {"Fave: " + car.color },
                {"vognstel: " + car.chassis_type },
                {"motorcylindre: " + car.engine_cylinders },
                {"motorvolumen: " + car.engine_volume },
                {"motoreffekt: " + car.engine_power },
                {"brændstoftype: " + car.fuel_type },
                {"registrering postnummer: " + car.registration_zipcode },
                {"køretøjs-id: " + car.vehicle_id },
                {"batch-id: " + car.batch_id }


            });

        }
        private void MakeTB(List<string> values)
        {
            foreach (var value in values)
            {
                SPCon.Children.Add(new TextBlock
                {
                    Text = value,
                    FontSize = 18

                });
            }
            
        }
        private async Task<Car> APICall(string U)
        {
            Car car = null;
            HttpClient client = new HttpClient();
            HttpRequestMessage httpRequestMessage = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(U),
                Headers = {
                    { HttpRequestHeader.Accept.ToString(), "application/json" },
                    {"X-AUTH-TOKEN","6ypq1yqvw3ccmz1c8a0g4p5w8aacztrb"}
                }
            };
            //client.BaseAddress = new Uri(URL);
            //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("X-AUTH-TOKEN", "tc60ppf002nch9lbkxza56m7mpm46s13");
            //client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            //HttpResponseMessage response = await client.GetAsync(U);
            var response = client.SendAsync(httpRequestMessage).Result;
            if (response.IsSuccessStatusCode)
            {
                car = await response.Content.ReadAsAsync<Car>();
            }

            return car;
            //datagrid.ItemsSource = await client.GetAsync
        }
    }
}
