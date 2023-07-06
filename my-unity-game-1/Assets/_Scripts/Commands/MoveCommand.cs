using System.Collections;
using UnityEngine;

namespace Birdy.Commands
{
	public class MoveCommand : ICommand
	{
		private GameObject _obj;
		private float _x, _y;
		private float _prevX, _prevY;

		public MoveCommand(GameObject obj, float x, float y)
		{
			_obj = obj;
			_x = x;
			_y = y;
		}

		public void Execute()
		{
			_prevX = _obj.transform.position.x;
			_prevY = _obj.transform.position.y;

			Vector3 pos = _obj.transform.position;
			pos.x = _x;
			pos.y = _y;
			_obj.transform.position = pos;
		}

		public void Undo()
		{
			Vector3 pos = _obj.transform.position;
			pos.x = _prevX;
			pos.y = _prevY;
			_obj.transform.position = pos;
		}

		public void Redo()
		{
			Vector3 pos = _obj.transform.position;
			pos.x = _x;
			pos.y = _y;
			_obj.transform.position = pos;
		}
	}

}