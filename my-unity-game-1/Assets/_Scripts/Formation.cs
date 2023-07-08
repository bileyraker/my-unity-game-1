using System.Collections;
using UnityEngine;

namespace Birdy
{
	public class Formation
	{
		public enum Types
		{
			MANUAL,
			LINE,
			BOX,
			SCATTER
		}
		private Types type;

		public Formation()
		{
			type = Types.MANUAL;
		}

		public void SetFormation(Types newFormation)
		{
			type = newFormation;
		}
	}
}