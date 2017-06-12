using System;
using System.Collections.Generic;

using Xamarin.Forms;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using System.Linq;
using static HideUtMob.Models.ClassJsonOem;

namespace HideUtMob.Views
{
    public partial class Oem : TabbedPage
    {


		DateTime theDate = DateTime.Now;
        Connectivity ins = new Connectivity();

		public DateTime TheDate
		{
			get
			{
				return theDate;
			}

			set
			{
				theDate = value;
				OnPropertyChanged();
			}
		}


        public Oem()
        {
            InitializeComponent();
			if (ins.GetConn().Equals("Is Connected"))
			{
                ButMes();
                ButSem();
                ButDia();
			}
			else
			{
				DisplayAlert("Connection error", "No internet\nconnection found", "OK");
			}
        }



		public async void ButMes()
		{
			try
			{
				indicator1.IsRunning = true;
				indLabel1.Text = "Please wait...";

				HttpClient client = new HttpClient();

				HttpResponseMessage res = await client.GetAsync("http://172.16.16.8:85/api/oemmes");
				var json = await res.Content.ReadAsStringAsync();

                var datos = JsonConvert.DeserializeObject<List<ClassJsonOemMes>>(json).OrderBy(p => p.Mes).ToList();


                indicator1.IsRunning = false;
				indLabel1.Text = "";

                lvInicio1.ItemsSource = datos;
			}
			catch (HttpRequestException)
			{
				indLabel1.Text = "";
				indicator1.IsRunning = false;
				await DisplayAlert("Error Connection", "Verifica tu Conexion", "OK");
			}
			catch (JsonReaderException)
			{
				indLabel1.Text = "";
				indicator1.IsRunning = false;
				await DisplayAlert("Error Connection", "Error al leer los datos,\nreinicia la app", "OK");
			}
			catch (JsonSerializationException)
			{
				indLabel1.Text = "";
				indicator1.IsRunning = false;
				await DisplayAlert("Error Connection", "Error al leer los datos,\nVerifica tu Conexion y reinicia la app", "OK");
			}

		}


		public async void ButSem()
		{
			try
			{
				indicator2.IsRunning = true;
				indLabel2.Text = "Please wait...";

				HttpClient client = new HttpClient();

				HttpResponseMessage res = await client.GetAsync("http://172.16.16.8:85/api/oemsemana");
				var json = await res.Content.ReadAsStringAsync();

                var datos = JsonConvert.DeserializeObject<List<ClassJsonOemSem>>(json).OrderBy(p => p.Semana).ToList();




				indicator2.IsRunning = false;
				indLabel2.Text = "";

				lvInicio2.ItemsSource = datos;
			}
			catch (HttpRequestException)
			{
				indLabel2.Text = "";
				indicator2.IsRunning = false;
				await DisplayAlert("Error Connection", "Verifica tu Conexion", "OK");
			}
			catch (JsonReaderException)
			{
				indLabel2.Text = "";
				indicator2.IsRunning = false;
				await DisplayAlert("Error Connection", "Error al leer los datos,\nreinicia la app", "OK");
			}
			catch (JsonSerializationException)
			{
				indLabel2.Text = "";
				indicator2.IsRunning = false;
				await DisplayAlert("Error Connection", "Error al leer los datos,\nVerifica tu Conexion y reinicia la app", "OK");
			}

		}

        public async void ButDia()
        {
			try
			{
				indicator3.IsRunning = true;
				indLabel3.Text = "Please wait...";

				HttpClient client = new HttpClient();

				HttpResponseMessage res = await client.GetAsync("http://172.16.16.8:85/api/oem");
				var json = await res.Content.ReadAsStringAsync();

                var DatosOem = JsonConvert.DeserializeObject<List<ClassOems>>(json).OrderBy(p => p.DescrOem).ToList();

				indicator3.IsRunning = false;
				indLabel3.Text = "";

                OemPicker.IsEnabled = true;
                OemPicker.ItemsSource = DatosOem;
			}
			catch (HttpRequestException)
			{
				indLabel3.Text = "";
				indicator3.IsRunning = false;
				await DisplayAlert("Error Connection", "Verifica tu Conexion", "OK");
			}
			catch (JsonReaderException)
			{
				indLabel3.Text = "";
				indicator3.IsRunning = false;
				await DisplayAlert("Error Connection", "Error al leer los datos,\nreinicia la app", "OK");
			}
			catch (JsonSerializationException)
			{
				indLabel3.Text = "";
				indicator3.IsRunning = false;
				await DisplayAlert("Error Connection", "Error al leer los datos,\nVerifica tu Conexion y reinicia la app", "OK");
			}
        }







        void ActualizarOemPage(object sender, System.EventArgs e)
        {
			if (ins.GetConn().Equals("Is Connected"))
			{
				ButMes();
				ButSem();
                ButDia();
			}
			else
			{
				DisplayAlert("Connection error", "No internet\nconnection found", "OK");
			}
        }


    }
}
