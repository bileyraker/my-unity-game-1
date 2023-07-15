using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

namespace Birdy.Players.Tools
{
	public class CameraRectangle : MonoBehaviour
	{
		[SerializeField]
		private WorldMap worldMap;
		private bool _snapToGrid = false;

		[SerializeField]
		private Camera _cam;

		private SpriteRenderer _spriteRenderer;
		private Collider2D _collider;
		private Rect _rect;
		private Vector2 _worldOrigin;
		private float _scaleFactor;
		private Vector3 _localScale;

		private void init()
		{
		}

		private void Awake()
		{
		}

		// Use this for initialization
		private void Start()
		{
			Debug.Log("CameraRectangle start");
			init();
		}

		private void OnEnable()
		{
			//if ( EventSystem.current.RaycastAll(Pointer.current.position, out var raycastResults))
			//{
			//	Debug.Log("Pointer over UI");
			//	enabled = false;
			//	return;
			//}
			Debug.Log("CameraRectangle init");
			if (_cam is null)
			{
				_cam = Camera.main;
			}
			if (_spriteRenderer is null)
			{
				_spriteRenderer = GetComponent<SpriteRenderer>();
			}
			_scaleFactor = _cam.orthographicSize;
			_localScale = new Vector3(_scaleFactor, _scaleFactor, 1);

			_spriteRenderer.enabled = true;
			Begin();
		}

		private void OnDisable()
		{
			Debug.Log("CameraRectangle disabled");
			_spriteRenderer.enabled = false;
		}

		// Update is called once per frame
		private void Update()
		{
			// Resize and rescale the transform in order to have the same size border no matter the camera viewport size
			Vector2 cursorLocation = Mouse.current.position.ReadValue();
			Vector2 worldLocation = _cam.ScreenToWorldPoint(cursorLocation);
			_scaleFactor = _cam.orthographicSize;
			transform.position = _worldOrigin;
			_localScale.x = _scaleFactor;
			_localScale.y = _scaleFactor;
			transform.localScale = _localScale;
			_spriteRenderer.size = (worldLocation - _worldOrigin) / _scaleFactor;
		}

		public void Begin()
		{
			_worldOrigin = _cam.ScreenToWorldPoint(Mouse.current.position.ReadValue());
			transform.position = _worldOrigin;
			//Update();
		}

		public Rect End()
		{
			Rect bounds = new Rect(transform.position, _spriteRenderer.size * _scaleFactor);
			//_collider.enabled = true;
			//GameObject duplicate = Instantiate(gameObject);
			//Destroy(duplicate.GetComponent<Tools.CameraRectangle>());
			Debug.Log($"CameraRectangle: <({bounds.xMin}, {bounds.yMin}), ({bounds.xMax}, {bounds.yMax})>");
			enabled = false;
			return bounds;
		}
	}
}