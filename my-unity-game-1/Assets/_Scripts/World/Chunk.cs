using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Birdy.Things;

namespace Birdy.World
{
	public class Chunk : MonoBehaviour
	{
		private List<IThing> thingList;

		// Use this for initialization
		void Start()
		{

		}

		// Update is called once per frame
		void Update()
		{

		}

		void Leave(IThing thing)
		{
			thingList.Remove(thing);
		}

		void Enter(IThing thing)
		{
			thingList.Add(thing);
		}
	}
}