using System.Collections;
using UnityEngine;

namespace Birdy
{
	public class SelectableObject
	{
		public int uid;
		private bool selected;

		public SelectableObject()
		{
			selected = false;
		}

		public void Select()
		{
			selected = true;
		}

		public void Deselect()
		{
			selected = false;
		}
	}
}