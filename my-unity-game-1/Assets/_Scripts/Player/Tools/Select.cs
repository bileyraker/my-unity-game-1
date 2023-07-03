using System.Collections.Generic;
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

		private CameraRectangle _rectangle;

		[SerializeField]
		private Selection _selector;

		private List<Selectable> _selectedThings;

		private Collider2D _collider;

		private void Awake()
		{
			playerControls = new PlayerInputActions();
			activateAction = playerControls.WorldCamera.Activate;
			activateAction.started += OnSelect;
			activateAction.canceled += EndSelect;


			cancelActivateAction = playerControls.WorldCamera.CancelActivate;
			cancelActivateAction.started += CancelSelect;


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
		}

		private void OnDisable()
		{
			Debug.Log("Select tool disabled");
			activateAction.Disable();
		}

		private void OnDestroy()
		{
			activateAction.started -= OnSelect;
			activateAction.canceled -= EndSelect;
		}

		private void OnSelect(InputAction.CallbackContext context)
		{
			Debug.Log("Select Started");
			_rectangle.enabled = true;
		}

		private void EndSelect(InputAction.CallbackContext context)
		{
			Debug.Log("Select Finished");
			Rect bounds = _rectangle.End();
			List<Collider2D> colliders = GetColliders(bounds);
			//List<Collider2D> selectableColliders = colliders.FindAll(x => x.TryGetComponent(out Selectable selectable));
			foreach (Collider2D collider in colliders)
			{
				if (collider.TryGetComponent<Selectable>(out Selectable selectable)){
					_selector.Select(selectable);
				}
			}
			//_rectangle.enabled = false;
		}

		private void CancelSelect(InputAction.CallbackContext context)
		{
			Debug.Log("Select Canceled");
			_rectangle.End();
			//_rectangle.enabled = false;
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