using Newtonsoft.Json;
using ppedv.Annoy_o_tron.Model;
using ppedv.Annoy_o_tron.Model.ApiDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XamApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
           
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            string url = "http://localhost:26302/api/ProcessDTOAPI";
            using (var wc = new WebClient())
            {
                var json = wc.DownloadString(url);


                var proc = JsonConvert.DeserializeObject<IEnumerable<ProcessDTO>>(json);
                listView.ItemsSource = proc;
            }
        }
    }
}
