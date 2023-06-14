using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Birdy
{
	interface ISelectable
	{
		List<Player> selectors { get; set; }

		void Select(Player a)
		{
			selectors.Add(a);
		}

		void Deselect(Player a)
		{
			selectors.Remove(a);
		}

		void PrintSelectors()
		{
			foreach (Player selector in selectors)
			{
				Debug.Log(selector.Name);
			}
		}
	}
}