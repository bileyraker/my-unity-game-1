using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Birdy.Things
{
	public class Inventory : MonoBehaviour
	{
		List<IThing> _items;
		List<IThing> _equipped;
		List<IWeapon> _equippedWeapons;

		private void Awake()
		{
			_items = new List<IThing>();
			_equipped = new List<IThing>();
		}

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