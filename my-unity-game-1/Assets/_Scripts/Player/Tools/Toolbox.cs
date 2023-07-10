using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Birdy.Player.Tools
{
	public class Toolbox : MonoBehaviour
	{
		public PlayerInputActions playerControls;
		private InputAction activate;

		////TODO: Should this be a gameobject? Or should I just instantiate a prefab?
		//[SerializeField]
		//private GameObject tool_SelectBox;

		[SerializeField]
		private List<Tool> tools;

		private void Awake()
		{
			//tools = new List<Tool>();
			playerControls = new PlayerInputActions();
		}

		// Start is called before the first frame update
		void Start()
		{
			foreach (Tool tool in tools)
			{
				//DeactivateTool(tool);
			}
		}

		private void OnEnable()
		{
			activate = playerControls.WorldCamera.Activate;
			activate.Enable();
			Debug.Log("Toolbox enabled");
		}

		private void OnDisable()
		{
			activate.Disable();
			Debug.Log("Toolbox disabled");
		}

		// Update is called once per frame
		void Update()
		{

		}

		public void ToggleTool(bool on, Tool tool)
		{
			if (tool is null) { throw new System.Exception("Oops"); }
			if (on)
			{
				ActivateTool(tool);
			}
			else
			{
				DeactivateTool(tool);
			}
		}

		private void ActivateTool(Tool tool)
		{
			Debug.Log($"Activating tool: {tool.name}");
			tool.enabled = true;
		}

		private void DeactivateTool(Tool tool)
		{
			Debug.Log($"Deactivating tool: {tool.name}");
			tool.enabled = false;
		}


	}
}
