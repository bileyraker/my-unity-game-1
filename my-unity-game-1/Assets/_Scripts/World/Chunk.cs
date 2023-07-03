using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Birdy.World
{
	public class Chunk : MonoBehaviour
	{
		private List<Thing> thingList;

		// Use this for initialization
		void Start()
		{

		}

		// Update is called once per frame
		void Update()
		{

		}

		void Leave(Thing thing)
		{
			thingList.Remove(thing);
		}

		void Enter(Thing thing)
		{
			thingList.Add(thing);
		}
	}
}