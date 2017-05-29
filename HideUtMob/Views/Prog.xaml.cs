using System;
using System.Collections.Generic;
using System.Net.Http;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace HideUtMob.Views
{
    public partial class Prog : TabbedPage
    {
        public Prog()
        {
            InitializeComponent();
			Connectivity ins = new Connectivity();
			if (ins.GetConn().Equals("Is Connected"))
			{
				//Datos();
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
				indicator1.IsRunning = true;
				indLabel1.Text = "Please wait...";

				HttpClient client = new HttpClient();

				HttpResponseMessage res = await client.GetAsync("http://leonmappserver/api/year");
				var json = await res.Content.ReadAsStringAsync();

				var Items = JsonConvert.DeserializeObject<List<ClassJSON.ModelYear>>(json);

				/*var datos = from p in Items
                            orderby p.Planta ascending
                            select p;*/


				indicator1.IsRunning = false;
				indLabel1.Text = "";

				//BindingContext = datos;
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



        void Handle_Clicked(object sender, System.EventArgs e)
        {
            But();
        }

    }
}
