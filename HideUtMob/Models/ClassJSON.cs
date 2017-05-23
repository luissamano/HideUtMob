using System;


namespace HideUtMob
{
	public class ClassJSON
	{
		public class ModelMeses
		{
			public string Planta { get; set; }
			public double Cueros { get; set; }
			public double PercentageUt { get; set; }
			public double HUtilizationVar { get; set; }
			public int Mes { get; set; }
			public int Año { get; set; }
		}


		public class ModelYear
		{
			public string Planta { get; set; }
			public int Año { get; set; }
			public double Cueros { get; set; }
			public double HUtilizationVar { get; set; }
		}





	}
}
