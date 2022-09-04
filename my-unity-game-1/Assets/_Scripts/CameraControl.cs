using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Birdy
{
	public class CameraControl : MonoBehaviour
	{
		public PlayerInputActions playerControls;
		private InputAction worldCameraPan;
		private InputAction worldCameraPanDrag;
		private InputAction worldCameraZoom;

		private Vector2 panDir;

		private Vector2 panTarget;
		private Vector2 panTargetVelocity;
		private bool panDragging = false;
		private bool mouseMoved;
		private Vector2 pd_ScreenOrigin;
		private Vector2 pd_WorldOrigin;
		private Vector2 pd_ScreenDest;
		private Vector2 pd_WorldDest;

		private bool zooming = false;
		private float zoomTarget;
		private Vector2 zoom_WorldOrigin;
		private Vector2 zoom_CursorLocation;

		private float zoomVelocity;
		private Vector2 panVelocity;

		public float panSpeed = 6f;
		public float zoomSpeed = 6f;
		public float panSmoothSpeed = 0.1f;
		public float zoomSmoothSpeed = 0.1f;
		public float zoomIncrement = 0.5f;

		private void Awake()
		{
			playerControls = new PlayerInputActions();
		}

		// Start is called before the first frame update
		void Start()
		{
			panTarget = (Vector2)transform.position;
			zoomTarget = Camera.main.orthographicSize;
			panVelocity = Vector2.zero;
			zoomVelocity = 0f;
		}


		private void OnEnable()
		{
			worldCameraPan = playerControls.WorldCamera.Pan;
			worldCameraPan.Enable();
			worldCameraPanDrag = playerControls.WorldCamera.PanDrag;
			worldCameraPanDrag.Enable();
			worldCameraZoom = playerControls.WorldCamera.Zoom;
			worldCameraZoom.Enable();

			playerControls.WorldCamera.Pan.performed += Pan;
			playerControls.WorldCamera.Pan.canceled += Pan;
			playerControls.WorldCamera.PanDrag.started += PanDrag;
			playerControls.WorldCamera.PanDrag.performed += PanDrag;
			playerControls.WorldCamera.PanDrag.canceled += PanDrag;
			playerControls.WorldCamera.Zoom.performed += Zoom;
		}

		private void OnDisable()
		{
			playerControls.WorldCamera.Pan.performed -= Pan;
			playerControls.WorldCamera.Pan.canceled -= Pan;
			playerControls.WorldCamera.PanDrag.started -= PanDrag;
			playerControls.WorldCamera.PanDrag.performed -= PanDrag;
			playerControls.WorldCamera.PanDrag.canceled -= PanDrag;
			playerControls.WorldCamera.Zoom.performed -= Zoom;

			worldCameraPan.Disable();
			worldCameraPanDrag.Disable();
			worldCameraZoom.Disable();
		}

		// Update is called once per frame
		private void Update()
		{
			UpdateZoom();
			UpdateTranslation();
		}

		private void Pan(InputAction.CallbackContext context)
		{
			Debug.Log("Pan: " + context.phase);
			if (context.performed)
			{
				panDir = context.ReadValue<Vector2>();
			}
			if (context.canceled)
			{
				panDir = Vector2.zero;
			}
		}

		private void PanDrag(InputAction.CallbackContext context)
		{
			if (context.started)
			{
				pd_ScreenOrigin = Mouse.current.position.ReadValue();
				pd_WorldOrigin = Camera.main.ScreenToWorldPoint(pd_ScreenOrigin);
			}
			else if (context.performed)
			{
				panDragging = true;
				mouseMoved = false;
				Debug.Log("panDragging = true");
			}
			else if (context.canceled)
			{
				Debug.Log("PanDrag Canceled");
				// For "pan to cursor" functionality
				// If mouse didn't move, pan to pd origin
				if (!mouseMoved)
				{
					Debug.Log("Pan to origin");
					panTarget = pd_WorldOrigin;
				}

				panDragging = false;
				Debug.Log("panDragging = false");
			}
		}

		private void Zoom(InputAction.CallbackContext context)
		{
			// Get cursor position
			zoom_CursorLocation = Mouse.current.position.ReadValue();
			zoom_WorldOrigin = Camera.main.ScreenToWorldPoint(zoom_CursorLocation);

			float val = context.ReadValue<float>();
			if(val < 0)
			{
				zoomTarget -= zoomIncrement;
			}
			else if(val > 0)
			{
				zoomTarget += zoomIncrement;
			}
			Debug.Log(context.phase + ": " + val);
			val = val / Mathf.Abs(val);
			zoomTarget -= val;
			zoomTarget = Mathf.Clamp(zoomTarget, 0.5f, 20f);
			if(!zooming)
			{
				zooming = true;
				Debug.Log("zooming = true, time = " + Time.time);
			}
		}

		private void UpdateTranslation()
		{
			if(panDragging)
			{
				Vector2 cursorLocation = Mouse.current.position.ReadValue();
				if(zooming)
				{
					zoom_CursorLocation = cursorLocation;
				}
				panTarget = WorldPointToScreenPoint(pd_WorldOrigin, cursorLocation);
				// For "pan to cursor" functionality
				// If mouse hasn't moved yet, determine if moved
				if (!mouseMoved && cursorLocation != pd_ScreenOrigin)
				{
					mouseMoved = true;
				}
			}

			Vector2 panTarget_Velocity = panSpeed * Camera.main.orthographicSize * panDir;
			Vector2 panDelta = panTarget_Velocity * Time.deltaTime;
			panTarget += panDelta;
			if (panDragging)
			{
				pd_WorldOrigin += panDelta;
			}
			if (zooming)
			{
				zoom_WorldOrigin += panDelta;
			}

			if (panTarget != (Vector2)transform.position)
			{
				transform.position = Vector2.SmoothDamp(transform.position, panTarget, ref panVelocity, .2f);
			}

		}

		private void UpdateZoom()
		{
			if (zooming)
			{
				if(Mathf.Abs(zoomTarget - Camera.main.orthographicSize) < zoomIncrement * .02)
				{
					Camera.main.orthographicSize = zoomTarget;
					zoomVelocity = 0;
					zooming = false;
					Debug.Log("zooming = false, time = " + Time.time);
				}
				else
				{
					Camera.main.orthographicSize = Mathf.SmoothDamp(Camera.main.orthographicSize, zoomTarget, ref zoomVelocity, .2f);

				}
				// Zoom towards/away from cursor. Cursor will stay on the same world coordinate.
				transform.position = WorldPointToScreenPoint(zoom_WorldOrigin, zoom_CursorLocation);
				panTarget = transform.position;
				//if(Mathf.Approximately(Camera.main.orthographicSize, zoomTarget))
				//{
				//	zooming = false;
				//	Debug.Log("zooming = false");
				//}
			}
		}

		// Returns the Vector2 that the camera transform needs to be located in order for worldPoint to be located at the mouse cursor.
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