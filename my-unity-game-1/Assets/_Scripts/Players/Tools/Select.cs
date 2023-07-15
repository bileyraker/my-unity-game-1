using Birdy.Commands;
using Birdy.Things.Components;
using System.Collections.Generic;
using System.Linq;
using UnityEditor.ShaderKeywordFilter;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

namespace Birdy.Players.Tools
{
	public class Select : Tool
	{
		public PlayerInputActions playerControls;
		public InputAction activateAction;
		public InputAction cancelActivateAction;
		public InputAction appendAction;

		private bool _append = false;

		private CameraRectangle _toolBrush;

		[SerializeField]
		private Selection _selector;

		private void Awake()
		{
			playerControls = new PlayerInputActions();
			// Select actions
			activateAction = playerControls.WorldCamera.Activate;
			// Beginning of select
			activateAction.started += Begin;
			// End of select
			activateAction.canceled += End;

			// Cancel select & do not change current selection
			cancelActivateAction = playerControls.WorldCamera.CancelActivate;
			cancelActivateAction.started += Cancel;

			// Modifier to append to current selection
			appendAction = playerControls.WorldCamera.Append;
			appendAction.started += SetAppend;
			appendAction.canceled += ResetAppend;

		}

		// Start is called before the first frame update
		void Start()
		{
			_player = transform.parent.gameObject;
			_toolBrush = GetComponent<Tools.CameraRectangle>();
		}

		private void OnEnable()
		{
			Debug.Log("Select tool enabled");
			activateAction.Enable();
			//cancelActivateAction.Enable();
			appendAction.Enable();
		}

		private void OnDisable()
		{
			Debug.Log("Select tool disabled");
			activateAction.Disable();
			cancelActivateAction.Disable();
			appendAction.Disable();
		}

		private void OnDestroy()
		{
			activateAction.started -= Begin;
			activateAction.canceled -= End;
			cancelActivateAction.started -= Cancel;
			appendAction.started -= SetAppend;
			appendAction.canceled -= ResetAppend;
		}

		private void Begin(InputAction.CallbackContext context)
		{
			PointerEventData pointerEvent = new PointerEventData(EventSystem.current);
			pointerEvent.position = Pointer.current.position.ReadValue();
			List<RaycastResult> uiHits = new List<RaycastResult>();
			EventSystem.current.RaycastAll(pointerEvent, uiHits);
			if (uiHits.Count != 0)
			{
				Debug.Log("Pointer over UI, cancelling tool.");
				return;
			}
			Debug.Log("Select Started");
			_toolBrush.enabled = true;
			cancelActivateAction.Enable();
		}

		private void End(InputAction.CallbackContext context)
		{
			cancelActivateAction.Disable();
			// If toolBrush is disabled (i.e. tool was canceled), do nothing
			// TODO: There may be a better way to implement this.
			if (!_toolBrush.enabled) { return; }

			// If not appending to selection, deselect everything first
			if (!_append)
			{
				_selector.Deselect();
			}

			Rect bounds = _toolBrush.End();
			List<Collider2D> colliders = GetColliders(bounds);
			List<IsSelectable> toSelect = new List<IsSelectable>();
			foreach (Collider2D collider in colliders)
			{
				if (collider.TryGetComponent<IsSelectable>(out IsSelectable selectable)){
					toSelect.Add(selectable);
				}
			}
			SelectCommand command = new SelectCommand(_selector, toSelect, _append);
			_selector.Select(toSelect);
			Debug.Log("Select Finished");
		}

		private void Cancel(InputAction.CallbackContext context)
		{
			Debug.Log("Select Canceled");
			_toolBrush.End();
			cancelActivateAction.Disable();
		}

		private void SetAppend(InputAction.CallbackContext context)
		{
			Debug.Log("set append");
			_append = true;
		}

		private void ResetAppend(InputAction.CallbackContext context)
		{
			Debug.Log("reset append");
			_append = false;
		}

		public List<Collider2D> GetColliders(Rect bounds)
		{
			Vector2 v1 = new Vector2(bounds.xMin, bounds.yMin);
			Vector2 v2 = new Vector2(bounds.xMax, bounds.yMax);
			Collider2D[] colliders = Physics2D.OverlapAreaAll(v1, v2);
			List<Collider2D> colliderList = colliders.ToList();
			Debug.Log($"Select found {colliderList.Count} colliders.");
			return colliderList;
		}
	}
}