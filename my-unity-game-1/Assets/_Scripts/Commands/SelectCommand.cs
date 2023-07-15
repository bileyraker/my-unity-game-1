using System.Collections;
using UnityEngine;
using Birdy.Things.Components;
using System.Collections.Generic;

namespace Birdy.Commands
{
	public class SelectCommand : ICommand
	{
		private List<IsSelectable> _toSelect;
		private Selection _selection;

		public SelectCommand(Selection selection, List<IsSelectable> toSelect, bool append)
		{
			_selection = selection;
			_toSelect = toSelect;
		}

		// TODO: To be able to undo properly, Select() should return a list of selectables that were actually used.
		// The _toSelect list should be updated to contain only selected selectables for undo history.

		public void Execute()
		{
			if (_toSelect is null)
			{
				Debug.LogWarning("SelectCommand executed with null list of objects.");
				return;
			}

			_selection.Select(_toSelect);
			
		}

		public void Undo()
		{
            if (_selection is null)
			{
				Debug.LogWarning("SelectCommand undone with null object.");
				return;
			}
			_selection.Deselect(_toSelect);
		}
	}

}