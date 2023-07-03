using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Birdy
{
	public class Selection : MonoBehaviour
	{
		private List<Selectable> _contents;
		private int _priorityLevel;

		void Awake()
		{
			_contents = new List<Selectable>();
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

		public List<Selectable> SelectedObjects
		{
			get => _contents;
		}

		public void Select(List<Selectable> toSelect)
		{
			foreach (var obj in toSelect)
			{
				_contents.Add(obj);
			}
		}

		public void Select(Selectable toSelect)
		{
			_contents.Add(toSelect);
			toSelect.Select();
		}

		public void Deselect(Selectable toDeselect)
		{
			_contents.Remove(toDeselect);
			toDeselect.Deselect();
		}

		public void Deselect(List<Selectable> toDeselect)
		{
			foreach (var obj in toDeselect)
			{
				Deselect(obj);
			}
		}

		public void Deselect()
		{
			foreach (var toDeselect in _contents)
			{
				Deselect(toDeselect);
			}
		}
	}
}