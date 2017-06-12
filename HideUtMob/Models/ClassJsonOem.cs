using System;
namespace HideUtMob.Models
{
    public class ClassJsonOem
    {

		public class ClassOems
		{
			public string OEM { get; set; }
			public string DescrOem { get; set; }
		}


		public class ClassJsonOemMes
        {
            public string Planta { get; set; }
            public string DescrOem { get; set; }
            public int Mes { get; set; }
            public int Año { get; set; }
            public int Cueros { get; set; }
            public double Porcentage { get; set; }
            public double HUtilizationVar { get; set; }
        }


        public class ClassJsonOemSem
        {
            public string Planta { get; set; }
            public string DescrOem { get; set; }
            public int Semana { get; set; }
            public int Año { get; set; }
            public int Cueros { get; set; }
            public double Porcentage { get; set; }
            public double HUtilizationVar { get; set; }
        }


        public class ClassOemFecha
        {
			public string Planta { get; set; }
			public string DescrOem { get; set; }
			public string Fecha { get; set; }
			public int Cueros { get; set; }
			public double Porcetage { get; set; }
			public double HUtilizationVar { get; set; }
        }

    }
}
