using System;
using System.Linq;
using System.Collections.Generic;
using System.Net.Http;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace HideUtMob
{
	public partial class Record : TabbedPage
	{
		public Record()
		{
			InitializeComponent();
            ButMes();
			ButSem();
			//ButDia();
		}
		
		public async void ButMes()
		{
            try
            {
                indicator1.IsRunning = true;
                indLabel1.Text = "Please wait...";

                HttpClient client = new HttpClient();
                HttpResponseMessage res = await client.GetAsync("http://leonmappserver/api/hidemeses");

                var json1 = await res.Content.ReadAsStringAsync();

                var Items1 = JsonConvert.DeserializeObject<List<ClassJSON.ModelMeses>>(json1);

                var datames = from a in Items1
                              orderby 
                                         a.Mes descending,
                                         a.Año descending

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
				indicator1.IsRunning = true;
				indLabel1.Text = "Please wait...";

				HttpClient client = new HttpClient();
				HttpResponseMessage res = await client.GetAsync("http://leonmappserver/api/hidesemanas");
				var json2 = await res.Content.ReadAsStringAsync();

                var Items2 = JsonConvert.DeserializeObject<List<ClassJSON.ModelSemanas>>(json2);

				var datasem = from a in Items2
							  orderby
										 a.Semana descending,
										 a.Año descending

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







	}
}