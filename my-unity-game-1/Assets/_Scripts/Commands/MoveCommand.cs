using System.Collections;
using UnityEngine;

namespace Birdy.Commands
{
	public class MoveCommand : ICommand
	{
		private IThing _obj;
		private float _x, _y, _z;
		private float _prevX, _prevY, _prevZ;

		public MoveCommand(IThing obj, float x, float y, float z)
		{
			_obj = obj;
			_x = x;
			_y = y;
			_z = z;

		}

		public void Execute()
		{
			_prevX = _obj.PositionTarget.x;
			_prevY = _obj.PositionTarget.y;
			_prevZ = _obj.PositionTarget.z;

			Vector3 pos = new Vector3(_x, _y, _z);
			_obj.PositionTarget = pos;
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