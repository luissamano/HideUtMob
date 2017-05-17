using System.Collections.Generic;
using System.Net.Http;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace HideUtMob
{
	public partial class HideUtMobPage
	{
		
		public HideUtMobPage()
		{
			InitializeComponent();
            But();
		}
		
		public async void But()
		{
			try
			{
				indicator.IsRunning = true;
				indLabel.Text = "Please wait...";
				indicator.BindingContext = lvData;

				HttpClient client = new HttpClient();
				HttpResponseMessage res = await client.GetAsync("http://webapihideutilization.azurewebsites.net/api/Meses");
				var json = await res.Content.ReadAsStringAsync();

				var Items = JsonConvert.DeserializeObject<List<ModelMeses>>(json);




			    lvData.ItemsSource = Items;
				indicator.IsRunning = false;
				indLabel.Text = "";
			}
			catch (HttpRequestException)
			{
				indLabel.Text = "";
				indicator.IsRunning = false;
				await DisplayAlert("Error Connection", "Verifica tu Conexion", "OK");
			}
			catch (JsonReaderException)
			{
				indLabel.Text = "";
				indicator.IsRunning = false;
				await DisplayAlert("Error Connection", "Error al leer los datos,\nreinicia la app", "OK");
			}
			catch (JsonSerializationException)
			{
				indLabel.Text = "";
				indicator.IsRunning = false;
				await DisplayAlert("Error Connection", "Error al leer los datos,\nVerifica tu Conexion y reinicia la app", "OK");
			}


		}



				
		
		public class ModelMeses
		{
			public string Planta { get; set; }
			public double Cueros { get; set; }
			public double PercentageUt { get; set; }
			public double HUtilizationVar { get; set; }
			public int Mes { get; set; }
			public int Año { get; set; }
		}

		void Handle_Clicked(object sender, System.EventArgs e)
		{
			Detail = new NavigationPage(new Record());
		}

		void Handle_Clicked1(object sender, System.EventArgs e)
		{
			
		}


	}
}
