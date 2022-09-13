using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Birdy
{
	public class ToolManager : MonoBehaviour
	{
		public PlayerInputActions playerControls;
		private InputAction select;

		//TODO: Should this be a gameobject? Or should I just instantiate a prefab?
		[SerializeField]
		private GameObject tool_SelectBox;

		private void Awake()
		{
			playerControls = new PlayerInputActions();
		}

		// Start is called before the first frame update
		void Start()
		{

		}

		private void OnEnable()
		{
			select = playerControls.WorldCamera.Select;
			select.Enable();

			playerControls.WorldCamera.Select.started += StartSelect;
			playerControls.WorldCamera.Select.canceled += FinishSelect;
		}

		// Update is called once per frame
		void Update()
		{

		}

		private void StartSelect(InputAction.CallbackContext context)
		{
			Debug.Log("Select Started");
			Tools.SelectBox sb = tool_SelectBox.GetComponent<Tools.SelectBox>();
			sb.Begin();
			tool_SelectBox.SetActive(true);
		}

		private void FinishSelect(InputAction.CallbackContext context)
		{
			Debug.Log("Select Finished");
			Tools.SelectBox sb = tool_SelectBox.GetComponent<Tools.SelectBox>();
			sb.End();
			tool_SelectBox.SetActive(false);
		}

		private void CancelSelect(InputAction.CallbackContext context)
		{
			Debug.Log("Select Canceled");
			tool_SelectBox.SetActive(false);
		}

	}
}
