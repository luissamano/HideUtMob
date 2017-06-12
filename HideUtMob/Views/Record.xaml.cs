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
			//ButDia();
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




                indicator1.IsRunning = false;
                indLabel1.Text = "";

                lvInicio1.ItemsSource = Items1.OrderBy(x => x.Mes);
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


        async void ButDia(object sender, System.EventArgs e)
        {

			try
			{

				indicator3.IsRunning = true;
				indLabel3.Text = "Please wait...";

                DateTime fecha = fechaRec.Date.ToLocalTime();

				HttpClient client = new HttpClient();
				HttpResponseMessage res = await client.GetAsync("http://172.16.16.8:8082/api/diashide");
				var json = await res.Content.ReadAsStringAsync();

                var Items = JsonConvert.DeserializeObject<List<ModelDias>>(json);

                var datasem = from n in Items
                        where n.Fecha.Year  == fecha.Year && n.Fecha.Day == fecha.Day && n.Fecha.Month == fecha.Month
                              orderby n.Planta
                              select n;


                indicator3.IsRunning = false;
				indLabel3.Text = "";
				lvInicio3.ItemsSource = datasem;

			}
			catch (HttpRequestException)
			{
				indicator3.IsRunning = false;
				indLabel3.Text = "";
				await DisplayAlert("Error Fecha", "Verifica tu Conexion", "OK");
			}
			catch (JsonReaderException)
			{
				indicator3.IsRunning = false;
				indLabel3.Text = "";
				await DisplayAlert("Error Fecha", "Error al leer los datos,\nreinicia la app", "OK");
			}
			catch (JsonSerializationException)
			{
				indicator3.IsRunning = false;
				indLabel3.Text = "";
				await DisplayAlert("Error Fecha", "Error al leer los datos,\nVerifica tu Conexion y reinicia la app", "OK");
			}
            
        }







	}
}