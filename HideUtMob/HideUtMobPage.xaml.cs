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
			HttpClient client = new HttpClient();
			HttpResponseMessage res = await client.GetAsync("http://webapihideutilization.azurewebsites.net/api/Meses");
			var json = await res.Content.ReadAsStringAsync();
			var Items = JsonConvert.DeserializeObject<List<ModelMeses>>(json);
			lvData.ItemsSource = Items;
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
