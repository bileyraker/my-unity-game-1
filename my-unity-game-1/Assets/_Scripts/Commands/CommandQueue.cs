using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

namespace Birdy.Commands
{
	// This should be used when we need the capability to undo something.
	public class CommandQueue : MonoBehaviour
	{
		// Commands are added to the queue by command invokers.
		// Commands are pushed on top of the undo stack from the front of the queue when processed.
		private Queue<ICommand> _queue = new Queue<ICommand>();
		// When a command is undone, it is popped from the undo stack and pushed to the redo stack.
		private Stack<ICommand> _undoStack = new Stack<ICommand>();
		// When a command is redone, it is popped from the redo stack and pushed to the undo stack.
		private Stack<ICommand> _redoStack = new Stack<ICommand>();


		// Process the first command in the queue
		private void ProcessCommand()
		{
			var command = _queue.Dequeue();
			_undoStack.Push(command);
			// Redo history is deleted once a command from the queue is processed
			_redoStack.Clear();
			command.Execute();
		}

		// Process the queue
		public void Process()
		{
			// Process all commands in the queue
			while(_queue.Count > 0)
			{
				ProcessCommand();
			}
		}

		// Add a command to the end of the queue
		public void Add(ICommand command)
		{
			_queue.Enqueue(command);
		}

		// Pop from undo stack, push to redo stack, then undo the command. Return the command.
		public ICommand Undo()
		{
			if (!_undoStack.TryPop(out ICommand command))
			{
				return null;
			}
			_redoStack.Push(command);
			command.Undo();
			return command;
		}

		// Pop from redo stack, push to undo stack, then execute the command. Return the command.
		public ICommand Redo()
		{
			if (!_redoStack.TryPop(out ICommand command))
			{
				return null;
			}
			_undoStack.Push(command);
			command.Execute();
			return command;
		}
	}
}