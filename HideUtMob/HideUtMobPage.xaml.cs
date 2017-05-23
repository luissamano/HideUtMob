using System.Collections.Generic;
using System.Linq;
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
			Connectivity ins = new Connectivity();
			if (ins.GetConn().Equals("Is Connected"))
			{
				But();
			}
			else
			{
				DisplayAlert("Connection error", "No internet\nconnection found", "OK");
			}

		}





		public async void But()
		{
			try
			{
				indicator.IsRunning = true;
				indLabel.Text = "Please wait...";

				HttpClient client = new HttpClient();

				HttpResponseMessage res = await client.GetAsync("http://leonmappserver/api/year");
				var json = await res.Content.ReadAsStringAsync();

				var Items = JsonConvert.DeserializeObject<List<ClassJSON.ModelYear>>(json);

				var datos = from p in Items
                            orderby p.Planta ascending
							select p;


				indicator.IsRunning = false;
				indLabel.Text = "";

                placeList.ItemsSource = datos;
                BindingContext = datos;
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










		void Handle_Clicked(object sender, System.EventArgs e)
		{
			Detail = new NavigationPage(new Record());
		}

		void Handle_Clicked1(object sender, System.EventArgs e)
		{

		}






	}
}
