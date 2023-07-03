using System.Collections;
using UnityEngine;
using Birdy.GameActors;

namespace Birdy.Commands
{
	public abstract class Command
	{
		public Command() { }

		~Command() { }

		public void Execute() { }

		public void Undo() { }
	}
}