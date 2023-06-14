using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Collections;

namespace Birdy
{
	public class SelectableObject : ISelectable
	{
		public int uid;
		[ReadOnly]
		private bool selected;

		List<Player> selectors { get; set; }


		public SelectableObject()
		{
			selected = false;
		}
		

		public void Select(Player a)
		{
			selectors.Add(a);
		}

		public void Deselect(Player a)
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