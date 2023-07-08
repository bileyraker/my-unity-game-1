using Birdy.Commands;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Birdy.Assets._Scripts.Commands
{
	public class CommandReceiver : MonoBehaviour
	{
		private CommandQueue _queue = new CommandQueue();

		public PlayerInputActions playerControls;
		public InputAction undoAction;
		public InputAction redoAction;

		private void Awake()
		{
			playerControls = new PlayerInputActions();
			undoAction = playerControls.WorldCamera.Undo;
			undoAction.performed += Undo;

			redoAction = playerControls.WorldCamera.Redo;
			redoAction.performed += Redo;
		}

		private void OnEnable()
		{
			undoAction.Enable();
			redoAction.Enable();
		}

		private void OnDisable()
		{
			undoAction.Disable();
			redoAction.Disable();
		}

		private void OnDestroy()
		{
			undoAction.performed -= Undo;
			redoAction.performed -= Redo;
		}

		// Update is called once per frame
		private void Update()
		{
			_queue.Process();
		}

		private void Undo(InputAction.CallbackContext context)
		{
			Debug.Log("Undo");
			ICommand command = _queue.Undo();
			if (command is not null)
			{ Debug.Log("Undone last command."); }
			else
			{ Debug.Log("Undo stack is empty."); }

		}

		private void Redo(InputAction.CallbackContext context)
		{
			Debug.Log("Redo");
			ICommand command = _queue.Redo();
			if (command is not null) 
				{ Debug.Log("Redone last undone command."); }
			else
				{ Debug.Log("Redo stack is empty."); }
		}
	}
}