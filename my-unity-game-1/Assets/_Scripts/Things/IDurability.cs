using System;
using System.Collections.Generic;
using UnityEngine;

namespace Birdy.Things
{
	public interface IDurability
	{

		float Durability { get; set; }
		float BaseDurability { get; set; }
		float MaxDurability { get; set; }

		public void Degrade(float amount)
		{
		}

		public void Mend(float amount)
		{
		}
	}
}