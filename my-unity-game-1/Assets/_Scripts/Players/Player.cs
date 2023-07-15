using System.Collections;
using UnityEngine;

namespace Birdy.Players
{
	public class Player : MonoBehaviour
	{
		private enum PlayerType
		{
			Undefined,
			Spectator,
			AI,
			Human
		}

		[SerializeField]
		private PlayerType type;

		// Use this for initialization
		void Start()
		{

		}

		// Update is called once per frame
		void Update()
		{

		}
	}
}