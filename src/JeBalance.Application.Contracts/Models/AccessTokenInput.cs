using System;
namespace JeBalance.Models
{
	public class AccessTokenInput
	{
        /// <summary>
        /// L'identifiant du client
        /// </summary>
        public string NameIdentifier { get; set; }

        /// <summary>
        /// Le nom commun associé au credential
        /// </summary>
        public string GivenName { get; set; }

        /// <summary>
        /// Les rôles pris en charge
        /// </summary>
        public string[] Roles { get; set; }
    }
}

