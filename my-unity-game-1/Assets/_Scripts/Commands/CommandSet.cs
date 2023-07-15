using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Birdy.Commands
{ 
	public class CommandSet
	{
		private List<ICommand> _commands;

		public List<ICommand> Commands { get { return _commands; } }

		public CommandSet() { _commands = new List<ICommand>(); }

		public void Add(ICommand command) {
			if (!_commands.Contains(command))
			{
				_commands.Add(command);
			}
		}

		public void Clear()
		{
			_commands.Clear();
		}


	}
}