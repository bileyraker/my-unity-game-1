using System.Collections;
using UnityEngine;
using Birdy.Things.Components;

namespace Birdy.Commands
{
	public class AttackCommand : ICommand
	{
		private CanAttack _obj;
		private Selection _target = null;
		private Selection _prevTarget = null;

		private World.Volume _areaTarget = null;
		private World.Volume _prevAreaTarget = null;

		private bool bPrevTargetWasArea;

		public float TimeIssued { get; set; } = -1f;

		public AttackCommand(CanAttack obj, Selection target)
		{
			_obj = obj;
			_target = target;
		}

		public AttackCommand(CanAttack obj, World.Volume target)
		{
			_obj = obj;
			_areaTarget = target;
		}

		public void Execute()
		{
			_obj.Target = _target;
		}

		public void Undo()
		{
			_obj.Target = _prevTarget;
		}
	}

}