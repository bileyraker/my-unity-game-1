using System.Collections;
using UnityEngine;

namespace Birdy.Commands
{
	public class SelectCommand : ICommand
	{
		private Selectable _obj;
		private Selection _selection;

		public SelectCommand(Selection, selection, Selectable obj, bool append)
		{
			_selection = 
			_obj = obj;
		}

		public void Execute()
		{
			if (_obj != null)
			{
				_obj.Select();
			}
		}

		public void Undo()
		{
			if (_obj != null)
			{
				_obj.Deselect();
			}
		}
	}

}