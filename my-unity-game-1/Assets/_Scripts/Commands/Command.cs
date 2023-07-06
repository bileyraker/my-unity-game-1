using System.Collections;
using UnityEngine;
using Birdy.GameActors;

namespace Birdy.Commands
{
	public abstract class Command
	{
		public Command() { }

		~Command() { }

		public abstract void Execute();

		public abstract void Undo();

		public abstract void Redo();

	}
}