using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Birdy
{
	namespace Tools
	{
		public class SelectBox : MonoBehaviour
		{
			[SerializeField]
			private WorldMap worldMap;

			[SerializeField]
			private Camera uiCamera;

			private SpriteRenderer spriteRenderer;
			private Vector2 worldOrigin;
			private float scaleFactor;

			private void Awake()
			{
				spriteRenderer = GetComponent<SpriteRenderer>();
			}

			// Use this for initialization
			void Start()
			{
				
			}

			private void OnEnable()
			{
				Debug.Log("SelectBox enabled");
			}

			private void OnDisable()
			{
				Debug.Log("SelectBox disabled");
			}

			// Update is called once per frame
			void Update()
			{
				if(isActiveAndEnabled)
				{
					scaleFactor = uiCamera.orthographicSize;
					Vector2 cursorLocation = Mouse.current.position.ReadValue();
					Vector2 worldLocation = uiCamera.ScreenToWorldPoint(cursorLocation);
					spriteRenderer.size = (worldLocation - worldOrigin) / scaleFactor;
					transform.position = worldOrigin;
					transform.localScale = new Vector3(uiCamera.orthographicSize, uiCamera.orthographicSize, 1);
				}

			}

			public void Begin()
			{
				worldOrigin = uiCamera.ScreenToWorldPoint(Mouse.current.position.ReadValue());
				transform.position = worldOrigin;
			}

			public void End()
			{
				Rect selectionBounds = new Rect(transform.position, spriteRenderer.size * scaleFactor);
				GameObject duplicate = Instantiate(gameObject);
				Destroy(duplicate.GetComponent<Tools.SelectBox>());
				Debug.Log("Selecting area of size = <" + selectionBounds.width + "," + selectionBounds.height + ">");
			}

			void Resize(float w, float h)
			{

			}

		}
	}
}