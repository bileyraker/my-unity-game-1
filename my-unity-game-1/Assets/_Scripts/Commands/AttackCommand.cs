using System.Collections;
using UnityEngine;

namespace Birdy.Commands
{
	public class AttackCommand : ICommand
	{
		private IThing _obj;
		private Selection _target;
		private Selection _prevTarget;

		public AttackCommand(CanAttack obj, Selection target)
		{
			_obj = obj;
			_target = target;
		}

		public void Execute()
		{

		}

		public void Undo()
		{
			Vector3 pos = new Vector3(_prevX, _prevY, _prevZ);
			pos.x = _prevX;
			pos.y = _prevY;
			pos.z = _prevZ;
			_obj.PositionTarget = pos;
		}
	}

}