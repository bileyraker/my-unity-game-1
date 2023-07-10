using Birdy.Commands;
using UnityEngine;

namespace Birdy.Player.Tools
{
	public abstract class Tool : MonoBehaviour
	{
		protected GameObject _player = null;

		protected CommandQueue _queue;
	}
}