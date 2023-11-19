using System;
using System.ComponentModel;

namespace JeBalance.Enums
{
	public enum eDelit
	{
		[Description("la fraude supposée est dissumulation de revenus")]
		dissimulaton,

		[Description("la fraude supposée est une évasion fiscale")]
		evasion
	}
}

