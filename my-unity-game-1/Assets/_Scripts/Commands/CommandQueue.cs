using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

namespace Birdy.Commands
{
	/// <summary>
	/// A queue of commands to be executed, with an undo and a redo stack.
	/// This should be used when we need the capability to undo something.
	/// Anything that happens in the game should go through one of these.
	/// </summary>
	// 
	public class CommandQueue
	{
		private struct SynchronizedCommand
		{
			public float timeIssued;
			public float timeExecuted;
			public ICommand command;
		}

		// TODO: The stacks may need to be linked lists so that we can remove the oldest commands
		// Instead of letting the stack reach infinity.

		/// <summary>
		/// Commands are added to the queue by command invokers.
		/// Commands are pushed to the undo stack from the front of the queue when processed.
		/// </summary>
		private Queue<SynchronizedCommand> _queue = new Queue<SynchronizedCommand>();

		/// <summary>
		/// When a command is undone, it is popped from the undo stack and pushed to the redo stack.
		/// </summary>
		private Stack<SynchronizedCommand> _undoStack = new Stack<SynchronizedCommand>();

		/// <summary>
		/// When a command is redone, it is popped from the redo stack and pushed to the undo stack.
		/// </summary>
		private Stack<SynchronizedCommand> _redoStack = new Stack<SynchronizedCommand>();

		/// <summary>
		/// Process the first command in the queue
		/// </summary>
		private void ProcessCommand()
		{
			var syncCommand = _queue.Dequeue();
			_undoStack.Push(syncCommand);
			// Redo history is deleted once a command from the queue is processed
			_redoStack.Clear();
			syncCommand.timeExecuted = Time.time;
			syncCommand.command.Execute();
		}

		/// <summary>
		/// Process the queue
		/// </summary>
		public void Process()
		{
			// Process all commands in the queue
			while(_queue.Count > 0)
			{
				ProcessCommand();
			}
		}

		/// <summary>
		/// Add a command to the end of the queue
		/// </summary>
		/// <param name="command"></param>
		public void Add(ICommand command)
		{
			SynchronizedCommand syncCommand = new SynchronizedCommand();
			syncCommand.command = command;
			syncCommand.timeIssued = Time.time;
			syncCommand.timeExecuted = -1f;
			_queue.Enqueue(syncCommand);
			
		}

		/// <summary>
		/// Pop from undo stack, push to redo stack, then undo the command. Return the command.
		/// </summary>
		/// <returns></returns>
		public ICommand Undo()
		{
			if (!_undoStack.TryPop(out SynchronizedCommand syncCommand))
			{
				return null;
			}
			_redoStack.Push(syncCommand);
			syncCommand.command.Undo();
			return syncCommand.command;
		}

		/// <summary>
		/// Pop from redo stack, push to undo stack, then execute the command. Return the command.
		/// </summary>
		/// <returns></returns>
		public ICommand Redo()
		{
			if (!_redoStack.TryPop(out SynchronizedCommand syncCommand))
			{
				return null;
			}
			_undoStack.Push(syncCommand);
			syncCommand.command.Execute();
			return syncCommand.command;
		}
	}
}