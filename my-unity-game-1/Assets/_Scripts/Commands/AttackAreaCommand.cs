using System.Collections;
using UnityEngine;
using Birdy.Things.Components;

namespace Birdy.Commands
{
	public class AttackAreaCommand : ICommand
	{
		private CanAttack _obj;
		private World.Volume _target;
		private World.Volume _prevTarget;

		public float TimeIssued { get; set; } = -1f;

		public AttackAreaCommand(CanAttack obj, World.Volume target)
		{
			_obj = obj;
			_target = target;
		}

		public void Execute()
		{
			
		}

		public void Undo()
		{
			_target = _prevTarget;
		}
	}

}