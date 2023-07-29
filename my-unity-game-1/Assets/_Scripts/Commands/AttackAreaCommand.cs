using System.Collections;
using UnityEngine;
using Birdy.Things.Components;

namespace Birdy.Commands
{
	public class AttackAreaCommand : ICommand
	{
		private CanAttack _obj;
		private World.Volume _target;
		private World.Volume _prevGroundTarget;

		private bool bPrevTargetWasVolume;

		public float TimeIssued { get; set; } = -1f;

		public AttackAreaCommand(CanAttack obj, World.Volume target)
		{
			_obj = obj;
			_target = target;
		}

		public void Execute()
		{
			bPrevTargetWasVolume = _obj.IsAttackingGround;
			if (bPrevTargetWasVolume)
			{
				_prevGroundTarget = _obj.GroundTarget;
			}

			_obj.GroundTarget = _target;
		}

		public void Undo()
		{
			if (bPrevTargetWasVolume)
			{
				_obj.GroundTarget = _prevGroundTarget;
			}
			else
			{
				_obj.Target = _prevTarget;
			}
			_target = _prevTarget;
		}
	}

}