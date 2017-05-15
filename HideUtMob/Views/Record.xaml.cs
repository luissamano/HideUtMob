using System;
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
			ButDia();
		}
		
		public async void ButMes()
		{
			HttpClient client = new HttpClient();
			HttpResponseMessage res = await client.GetAsync("http://webapihideutilization.azurewebsites.net/api/Meses");
			var json1 = await res.Content.ReadAsStringAsync();
			var Items1 = JsonConvert.DeserializeObject<List<ModelMeses>>(json1);
			lvData1.ItemsSource = Items1;
		}

		public async void ButSem()
		{
			HttpClient client = new HttpClient();
			HttpResponseMessage res = await client.GetAsync("http://webapihideutilization.azurewebsites.net/api/Semanas");
			var json2 = await res.Content.ReadAsStringAsync();
			var Items2 = JsonConvert.DeserializeObject<List<ModelSemanas>>(json2);
			lvData2.ItemsSource = Items2;
		}

		public async void ButDia()
		{
			HttpClient client = new HttpClient();
			HttpResponseMessage res = await client.GetAsync("http://webapihideutilization.azurewebsites.net/api/Dias");
			var json3 = await res.Content.ReadAsStringAsync();
			var Items3 = JsonConvert.DeserializeObject<List<ModelDias>>(json3);
			lvData3.ItemsSource = Items3;
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

		public class ModelSemanas
		{
			public string Planta { get; set; }
			public double Cueros { get; set; }
			public double PercentageUt { get; set; }
			public double HUtilizationVar { get; set; }
			public int Semana { get; set; }
			public int Año { get; set; }
		}

		public class ModelDias
		{
			public string Planta { get; set; }
			public double Cueros { get; set; }
			public double PercentageUt { get; set; }
			public double HUtilizationVar { get; set; }
			public int Dia { get; set; }
			public int Año { get; set; }
			public int Mes { get; set; }
		}


	}
}