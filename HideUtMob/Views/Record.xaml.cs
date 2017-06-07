using System;
using System.Linq;
using System.Collections.Generic;
using System.Net.Http;
using Newtonsoft.Json;
using Xamarin.Forms;
using static HideUtMob.ClassJSON;

namespace HideUtMob
{
	public partial class Record : TabbedPage
	{


		DateTime theDateRec = DateTime.Now;

		public DateTime TheDate
		{
			get
			{
				return theDateRec;
			}

			set
			{
				theDateRec = value;
				OnPropertyChanged();
			}
		}


		public Record()
		{
			InitializeComponent();
            ButMes();
			ButSem();
			ButDia();
		}
		
		public async void ButMes()
		{
            try
            {
                indicator1.IsRunning = true;
                indLabel1.Text = "Please wait...";

                HttpClient client = new HttpClient();
                HttpResponseMessage res = await client.GetAsync("http://172.16.16.8:8082/api/meseshide");

                var json1 = await res.Content.ReadAsStringAsync();

                var Items1 = JsonConvert.DeserializeObject<List<ModelMeses>>(json1);

                var datames = from a in Items1
                              orderby 
                                         a.Mes ascending,
                                         a.Año ascending

                              select a;


                indicator1.IsRunning = false;
                indLabel1.Text = "";

                lvInicio1.ItemsSource = datames;
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
				HttpResponseMessage res = await client.GetAsync("http://172.16.16.8:8082/api/semanashide");
				var json2 = await res.Content.ReadAsStringAsync();

                var Items2 = JsonConvert.DeserializeObject<List<ModelSemanas>>(json2);

				var datasem = from a in Items2
							  orderby
										 a.Semana ascending,
										 a.Año ascending

							  select a;


				indicator2.IsRunning = false;
				indLabel2.Text = "";

                lvInicio2.ItemsSource = datasem;
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


        public async void ButDia ()
        {

			try
			{

				HttpClient client = new HttpClient();
				HttpResponseMessage res = await client.GetAsync("http://172.16.16.8:8082/api/fechahide");
				var json = await res.Content.ReadAsStringAsync();

				var Items = JsonConvert.DeserializeObject<List<ModelSemanas>>(json);

				var datasem = from a in Items
							  orderby
										 a.Semana ascending,
										 a.Año ascending

							  select a;


				fechaRec.IsEnabled = true;


			}
			catch (HttpRequestException)
			{
				await DisplayAlert("Error Fecha", "Verifica tu Conexion", "OK");
			}
			catch (JsonReaderException)
			{
				await DisplayAlert("Error Fecha", "Error al leer los datos,\nreinicia la app", "OK");
			}
			catch (JsonSerializationException)
			{
				await DisplayAlert("Error Fecha", "Error al leer los datos,\nVerifica tu Conexion y reinicia la app", "OK");
			}
            
        }







	}
}