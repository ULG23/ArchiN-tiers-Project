using System;
namespace JeBalance.Models
{
	public class AccesToken
	{
		public AccesToken()
		{
		}

		public string Token { get; set; }

		public DateTime IssuedDateTime { get; set; }

		public int Lifetime { get; set; }

    }
}

