using System;
using Plugin.Connectivity;

namespace HideUtMob
{
	public class Connectivity
	{
		private string Conn;

		public Connectivity()
		{
			Conne();
		}

		private void Conne()
		{
			if (CrossConnectivity.Current.IsConnected) 
			{
				Conn = "Is Connected"; 
			} 
			else
			{
				Conn = "Isn't Connected";
			}
		}


		public string GetConn()
		{
			return Conn;
		}


	}
}
