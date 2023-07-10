using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Birdy
{
	// Each player has a selection.
	// When something has a target, it will be a selection
	public class Selection : MonoBehaviour
	{
		[SerializeField]
		private List<Selectable> _contents;
		private int _priorityLevel = 0;

		void Awake()
		{
			_contents = new List<Selectable>();
		}

		private void Start()
		{

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
			if (_contents.Any(x => x.GetInstanceID() == toSelect.GetInstanceID()))
			{
				return;
			}
			_contents.Add(toSelect);
			toSelect.Select();
		}

		public void Deselect(Selectable toDeselect)
		{
			toDeselect.Deselect();
			_contents.Remove(toDeselect);
		}

		public void Deselect(List<Selectable> toDeselect)
		{
			for (int i = toDeselect.Count - 1; i >= 0; i--)
			{
				toDeselect[i].Deselect();
			}
		}

		public void Deselect()
		{
			for (int i = _contents.Count - 1; i >= 0; i--)
			{
				Deselect(_contents[i]);
			}
		}
	}
}