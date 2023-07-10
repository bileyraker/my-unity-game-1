using System.Collections;
using UnityEngine;

namespace Birdy.Assets._Scripts.Commands
{
	public class CommandInvoker : MonoBehaviour
	{
		private Selection _selection;

		// Use this for initialization
		void Start()
		{
			TryGetComponent<Selection>(out _selection);
		}

		// Update is called once per frame
		void Update()
		{

		}
	}
}