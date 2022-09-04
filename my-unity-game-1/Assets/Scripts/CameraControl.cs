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

		public float panSpeed = 6f;
		public float zoomSpeed = 6f;
		public float panLerpSpeed = 0.02f;
		public float zoomLerpSpeed = 0.02f;
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
			zooming = true;
		}

		private void UpdateTranslation()
		{
			if(panDragging)
			{
				Vector2 cursorLocation = Mouse.current.position.ReadValue();
				panTarget = WorldPointToCursor(pd_WorldOrigin, cursorLocation);
				// For "pan to cursor" functionality
				// If mouse hasn't moved yet, determine if moved
				if (!mouseMoved && cursorLocation != pd_ScreenOrigin)
				{
					mouseMoved = true;
				}
			}

			Vector2 panTargetVelocity = panSpeed * Camera.main.orthographicSize * panDir;
			Vector2 panDelta = panTargetVelocity * Time.deltaTime;
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
				// Lerp towards panTarget.
				//transform.position = Vector2.Lerp(transform.position, panTarget, panLerpSpeed);

				// Don't lerp, instead pan a fixed speed until close, then pan slower.
				transform.position = Vector2.MoveTowards(
					(Vector2) transform.position,
					panTarget,
					panSpeed * Camera.main.orthographicSize * Time.deltaTime);
			}

		}

		private void UpdateZoom()
		{
			if (zooming)
			{

				if (Camera.main.orthographicSize < 0.998 * zoomTarget || Camera.main.orthographicSize > 1.002 * zoomTarget)
				{
					//Camera.main.orthographicSize = Mathf.Lerp(Camera.main.orthographicSize, zoomTarget, zoomLerpSpeed);
					Camera.main.orthographicSize = Mathf.MoveTowards(
						Camera.main.orthographicSize, 
						zoomTarget, 
						zoomSpeed * Time.deltaTime);
				}
				else
				{
					Camera.main.orthographicSize = zoomTarget;
					zooming = false;
				}

				// Zoom towards/away from cursor. Cursor will stay on the same world coordinate.
				transform.position = WorldPointToCursor(zoom_WorldOrigin, zoom_CursorLocation);
				panTarget = transform.position;
			}
		}

		// Returns the Vector2 that the camera transform needs to be located in order for worldPoint to be located at the mouse cursor.
		private Vector2 WorldPointToCursor(Vector2 worldPoint, Vector2 cursorLocation)
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