using System.Collections;
using UnityEngine;
using Birdy.GameActors;

namespace Birdy.Commands
{
	public interface ICommand
	{
		void Execute();
		void Undo();
	}
}