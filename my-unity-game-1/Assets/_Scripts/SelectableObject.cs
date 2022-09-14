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

		public SelectableObject()
		{
			selected = false;
		}

		public void Select()
		{
			selected = true;
			Debug.Log("UID: " + uid + " | selected");
		}

		public void Deselect()
		{
			selected = false;
			Debug.Log("UID: " + uid + " | deselected");
		}
	}
}