using System.Collections.Generic;
using UnityEngine;

namespace Birdy
{
	public abstract class RuntimeSet<T> : ScriptableObject
	{
		private List<T> items = new List<T>();
		public List<T> Items { 
			get { return items; } 
			private set { items = value; }
		}


		public void Initialize()
		{
			items.Clear();
		}

		public T GetItem(int index)
		{
			if (index >= items.Count)
			{
				string errorMsg = $"Attempted to get item from runtime set with index {index} but runtime set only has {items.Count} items.";
				Debug.Log(errorMsg);
				throw new System.Exception(errorMsg);
			}
			return items[index];
		}

		public void Add(T thing)
		{
			if (!items.Contains(thing))
				items.Add(thing);
		}

		public void Remove(T toRemove)
		{
			if (items.Contains(toRemove))
				items.Remove(toRemove);
			else
				Debug.Log("Attempted to remove an item from runtime set, but item does not exist in runtime set");
		}
	}
}