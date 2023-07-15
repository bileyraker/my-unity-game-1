using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Birdy.Things.Components;

namespace Birdy
{
	// Each player has a selection.
	// When something has a target, it will be a selection
	public class Selection : MonoBehaviour
	{
		[SerializeField]
		private List<IsSelectable> _contents;
		private int _priorityLevel = 0;

		void Awake()
		{
			_contents = new List<IsSelectable>();
		}

		private void Start()
		{

		}

		// Update is called once per frame
		void Update()
		{

		}

		public List<IsSelectable> SelectedObjects
		{
			get => _contents;
		}

		public void Select(List<IsSelectable> toSelect)
		{
			foreach (var obj in toSelect)
			{
				Select(toSelect);
			}
		}

		public void Select(IsSelectable toSelect)
		{
			// Do not select any that are already selected by this
			if (_contents.Any(x => x.GetInstanceID() == toSelect.GetInstanceID()))
			{
				return;
			}

			// Add to contents and notify the object that it has been selected.
			_contents.Add(toSelect);
			toSelect.Select();
		}

		public void Deselect(IsSelectable toDeselect)
		{
			toDeselect.Deselect();
			_contents.Remove(toDeselect);
		}

		public void Deselect(List<IsSelectable> toDeselect)
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