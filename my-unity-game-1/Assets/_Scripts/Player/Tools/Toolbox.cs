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

		[SerializeField]
		private Select tool_Select;

		private void Awake()
		{
			tools = new List<Tool>();
			playerControls = new PlayerInputActions();
		}

		// Start is called before the first frame update
		void Start()
		{
		}

		private void OnEnable()
		{
			activate = playerControls.WorldCamera.Activate;
			activate.Enable();
			Debug.Log("activate enabled");
		}

		private void OnDisable()
		{
			activate.Disable();
			Debug.Log("activate disabled");
		}

		// Update is called once per frame
		void Update()
		{

		}

		void ActivateTool()
		{

		}

		void DeactivateTool(Tool tool)
		{

		}


	}
}
