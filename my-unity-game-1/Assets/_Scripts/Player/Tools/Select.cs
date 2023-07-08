﻿using System.Collections.Generic;
using System.Linq;
using UnityEditor.ShaderKeywordFilter;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Birdy.Player.Tools
{
	public class Select : Tool
	{
		public PlayerInputActions playerControls;
		public InputAction activateAction;
		public InputAction cancelActivateAction;
		public InputAction appendAction;

		private bool _append = false;

		private CameraRectangle _rectangle;

		[SerializeField]
		private Selection _selector;

		private List<Selectable> _selectedThings;

		private Collider2D _collider;

		private void Awake()
		{
			playerControls = new PlayerInputActions();
			// Select actions
			activateAction = playerControls.WorldCamera.Activate;
			// Beginning of select
			activateAction.started += OnSelect;
			// End of select
			activateAction.canceled += EndSelect;

			// Cancel select & do not change current selection
			cancelActivateAction = playerControls.WorldCamera.CancelActivate;
			cancelActivateAction.started += CancelSelect;

			// Modifier to append to current selection
			appendAction = playerControls.WorldCamera.Append;
			appendAction.started += SetAppend;
			appendAction.canceled += ResetAppend;

		}

		// Start is called before the first frame update
		void Start()
		{
			_player = transform.parent.gameObject;
			_rectangle = GetComponent<Tools.CameraRectangle>();
			_collider = _rectangle.GetComponent<Collider2D>();
		}

		private void OnEnable()
		{
			Debug.Log("Select tool enabled");
			activateAction.Enable();
			cancelActivateAction.Enable();
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
			activateAction.started -= OnSelect;
			activateAction.canceled -= EndSelect;
			cancelActivateAction.started -= CancelSelect;
			appendAction.started -= SetAppend;
			appendAction.canceled -= ResetAppend;
		}

		private void OnSelect(InputAction.CallbackContext context)
		{
			Debug.Log("Select Started");
			_rectangle.enabled = true;
		}

		private void EndSelect(InputAction.CallbackContext context)
		{
			if (!_rectangle.enabled) { return; }
			if (!_append)
			{
				_selector.Deselect();
			}

			Rect bounds = _rectangle.End();
			List<Collider2D> colliders = GetColliders(bounds);
			//List<Collider2D> selectableColliders = colliders.FindAll(x => x.TryGetComponent(out Selectable selectable));
			foreach (Collider2D collider in colliders)
			{
				if (collider.TryGetComponent<Selectable>(out Selectable selectable)){
					_selector.Select(selectable);
				}
			}
			Debug.Log("Select Finished");
		}

		private void CancelSelect(InputAction.CallbackContext context)
		{
			Debug.Log("Select Canceled");
			_rectangle.End();
			//_rectangle.enabled = false;
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