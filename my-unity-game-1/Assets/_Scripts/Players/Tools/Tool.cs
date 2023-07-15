using Birdy.Commands;
using UnityEngine;

namespace Birdy.Players.Tools
{
	public abstract class Tool : MonoBehaviour
	{
		protected GameObject _player = null;

		protected CommandQueue _queue;
	}
}