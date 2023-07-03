using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Birdy
{
	public class CameraControl : MonoBehaviour
	{
		[System.Serializable]
		public class Panner
		{
			private CameraControl parent;
			private Vector2 dir;
			public Vector2 target;
			private Vector2 targetVelocity;
			private bool dragging = false;
			private bool mouseMoved;
			private Vector2 screenOrigin;
			private Vector2 worldOrigin;
			private Vector2 velocity;

			[SerializeField]
			private float speed = 6f;
			[SerializeField]
			private float duration = 0.08f;

			public Panner(CameraControl obj)
			{
				parent = obj;
				velocity = Vector2.zero;
			}

			public void Pan(InputAction.CallbackContext context)
			{
				if (context.performed)
				{
					dir = context.ReadValue<Vector2>();
				}
				if (context.canceled)
				{
					dir = Vector2.zero;
				}
			}

			public void PanDrag(InputAction.CallbackContext context)
			{
				if (context.started)
				{
					screenOrigin = Mouse.current.position.ReadValue();
					worldOrigin = Camera.main.ScreenToWorldPoint(screenOrigin);
				}
				else if (context.performed)
				{
					dragging = true;
					mouseMoved = false;
				}
				else if (context.canceled)
				{
					// For "pan to cursor" functionality
					// If mouse didn't move, pan to pd origin
					if (!mouseMoved)
					{
						target = worldOrigin;
					}

					dragging = false;
				}
			}

			public void UpdateTranslation()
			{
				if (dragging)
				{
					Vector2 cursorLocation = Mouse.current.position.ReadValue();
					//if (parent.zoomer.zooming)
					//{
					//	parent.zoomer.cursorOrigin = cursorLocation;
					//}
					target = parent.WorldPointToScreenPoint(worldOrigin, cursorLocation);
					// For "pan to cursor" functionality
					// If mouse hasn't moved yet, determine if moved
					if (!mouseMoved && cursorLocation != screenOrigin)
					{
						mouseMoved = true;
					}
				}

				Vector2 panTarget_Velocity = speed * Camera.main.orthographicSize * dir;
				Vector2 panDelta = panTarget_Velocity * Time.deltaTime;
				target += panDelta;
				if (dragging)
				{
					worldOrigin += panDelta;
				}
				//if (zooming)
				//{
				//	zoom_WorldOrigin += panDelta;
				//}

				if (target != (Vector2) parent.transform.position)
				{
					parent.transform.position = Vector2.SmoothDamp(parent.transform.position, target, ref velocity, duration);
				}

			}
		}

		[System.Serializable]
		public class Zoomer
		{
			private CameraControl parent;

			public bool zooming = false;
			public float target;
			private Vector2 worldOrigin;
			private Vector2 cursorOrigin;
			private float velocity;

			[SerializeField]
			private float duration = 0.1f;
			private float increment = 0.5f;

			public Zoomer(CameraControl obj)
			{
				parent = obj;
				velocity = 0f;
			}

			public void Zoom(InputAction.CallbackContext context)
			{
				// Get cursor position
				cursorOrigin = Mouse.current.position.ReadValue();
				worldOrigin = Camera.main.ScreenToWorldPoint(cursorOrigin);

				// TODO: Increment should change based on current zoom level
				// The further out the camera is, the higher the increment should be
				// Perhaps just use an array of valid zoom levels and slide up and down that array
				float val = context.ReadValue<float>();
				if (val < 0)
				{
					target -= increment;
				}
				else if (val > 0)
				{
					target += increment;
				}
				val = val / Mathf.Abs(val);
				target -= val;
				target = Mathf.Clamp(target, 0.5f, 20f);
				zooming = true;
			}

			public void UpdateZoom()
			{
				if (zooming)
				{
					if (Mathf.Abs(target - Camera.main.orthographicSize) < increment * .02)
					{
						Camera.main.orthographicSize = target;
						velocity = 0;
						zooming = false;
						Debug.Log("zooming = false, time = " + Time.time);
					}
					else
					{
						Camera.main.orthographicSize = Mathf.SmoothDamp(Camera.main.orthographicSize, target, ref velocity, duration);

					}
					// Zoom towards/away from cursor. Cursor will stay on the same world coordinate.
					// Cursor will, however, change if currently panDragging. It should move to wherever 

					parent.transform.position = parent.WorldPointToScreenPoint(worldOrigin, cursorOrigin);
					parent.panner.target = parent.transform.position;
				}
			}

		}

		[SerializeField]
		private Panner panner;
		[SerializeField]
		private Zoomer zoomer;

		public PlayerInputActions playerControls;
		private InputAction worldCameraPan;
		private InputAction worldCameraPanDrag;
		private InputAction worldCameraZoom;

		private void Awake()
		{
			playerControls = new PlayerInputActions();
			panner = new Panner(this);
			zoomer = new Zoomer(this);
		}

		void Start()
		{
			panner.target = (Vector2)transform.position;
			zoomer.target = Camera.main.orthographicSize;
		}


		private void OnEnable()
		{
			worldCameraPan = playerControls.WorldCamera.Pan;
			worldCameraPan.Enable();
			worldCameraPanDrag = playerControls.WorldCamera.PanDrag;
			worldCameraPanDrag.Enable();
			worldCameraZoom = playerControls.WorldCamera.Zoom;
			worldCameraZoom.Enable();

			playerControls.WorldCamera.Pan.performed += panner.Pan;
			playerControls.WorldCamera.Pan.canceled += panner.Pan;
			playerControls.WorldCamera.PanDrag.started += panner.PanDrag;
			playerControls.WorldCamera.PanDrag.performed += panner.PanDrag;
			playerControls.WorldCamera.PanDrag.canceled += panner.PanDrag;
			playerControls.WorldCamera.Zoom.performed += zoomer.Zoom;
		}

		private void OnDisable()
		{
			playerControls.WorldCamera.Pan.performed -= panner.Pan;
			playerControls.WorldCamera.Pan.canceled -= panner.Pan;
			playerControls.WorldCamera.PanDrag.started -= panner.PanDrag;
			playerControls.WorldCamera.PanDrag.performed -= panner.PanDrag;
			playerControls.WorldCamera.PanDrag.canceled -= panner.PanDrag;
			playerControls.WorldCamera.Zoom.performed -= zoomer.Zoom;

			worldCameraPan.Disable();
			worldCameraPanDrag.Disable();
			worldCameraZoom.Disable();
		}

		// Update is called once per frame
		private void Update()
		{
			zoomer.UpdateZoom();
			panner.UpdateTranslation();
		}

		// TODO: This probably ought to be in a different class
		private Vector2 WorldPointToScreenPoint(Vector2 worldPoint, Vector2 cursorLocation)
		{
			// Get cursorLocation's world coordinates
				//pd_WorldDest = Camera.main.ScreenToWorldPoint(cursorLocation);
			Vector2 worldDest = Camera.main.ScreenToWorldPoint(cursorLocation);
			// Get the delta between worldPoint and that coordinate
			Vector2 delta = worldDest - worldPoint;
			// 4. Get the absolute location
			Vector2 val = (Vector2)transform.position - delta;

			return val;
		}

	}
}