using System.Collections;
using UnityEngine;
using Birdy.GameActors;

namespace Birdy.Commands
{
	public interface ICommand
	{
		public void Execute();
		public void Undo();
	}
}