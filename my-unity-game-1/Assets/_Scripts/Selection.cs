using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Birdy
{
	public class Selection
	{
		private List<SelectableObject> selection;

		void Awake()
		{

			selection = new List<SelectableObject>();
		}

		private void Start()
		{

			//var d = new SelectableObject() { uid = 3 };
			//selection.Add(new SelectableObject() { uid = 1 });
			//selection.Add(new SelectableObject() { uid = 2 });
			//selection.Add(d);

			//foreach (var obj in selection)
			//{
			//	Debug.Log("obj.uid=" + obj.uid);
			//}

			//Deselect(d);

			//foreach (var obj in selection)
			//{
			//	Debug.Log("obj.uid=" + obj.uid);
			//}
			//Debug.Log("End");
		}

		// Update is called once per frame
		void Update()
		{

		}

		public Selection()
		{
			selection = new List<SelectableObject>();
		}

		public List<SelectableObject> SelectedObjects
		{
			get
			{
				return selection;
			}
		}

		public void Select(List<SelectableObject> toSelect)
		{
			foreach (var obj in toSelect)
			{
				// Check if already selected by player
				if (!selection.Exists(x => x.uid == obj.uid))
				{
					selection.Add(obj);
				}

			}
		}

		public void Deselect(List<SelectableObject> toDeselect)
		{
			foreach (var obj in toDeselect)
			{
				Deselect(obj);
			}
		}

		public void Deselect(SelectableObject toDeselect)
		{
			var foundObj = selection.Find(x => x.uid == toDeselect.uid);
			var contains = selection.Contains(toDeselect);
			if (foundObj.uid == toDeselect.uid)
			{
				toDeselect.Deselect();
				selection.Remove(toDeselect);
			}
		}

		public void Deselect()
		{
			foreach (var obj in selection)
			{
				Deselect(obj);
			}
			selection.Clear();
		}
	}
}