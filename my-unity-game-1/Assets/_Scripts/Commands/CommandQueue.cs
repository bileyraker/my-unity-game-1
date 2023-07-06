using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Birdy.Commands
{
	public class CommandQueue : MonoBehaviour
	{
		private List<ICommand> _commandBuffer = new List<ICommand>();
		private int _commandIndex = 0;

		public void Add(ICommand command)
		{
			_commandBuffer.Add(command);
			_commandIndex = _commandBuffer.Count - 1;
		}

		// Use this for initialization
		void Start()
		{

		}

		// Update is called once per frame
		void Update()
		{

		}
	}
}