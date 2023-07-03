﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Birdy
{
    public class Selectable : MonoBehaviour
    {
		[SerializeField]
		private int selectors = 0;

		private Material _originalMaterial;

		[SerializeField]
		private Material _selectedMaterial;

		[SerializeField]
		private SpriteRenderer _renderer;

		[SerializeField]
		private int _priority = 0;

		public int Priority { get { return _priority; }}

		private void Start()
		{
			if(_originalMaterial is null)
				_originalMaterial = _renderer.material;
			_priority = CalculatePriority();
		}

		private int CalculatePriority()
		{
			return 0;
		}

		public bool Selected()
		{
			if (selectors > 0) { return true; }
			return false;
		}

		public void Select()
		{
			Debug.Log($"UID: {GetInstanceID()} | {name} | selected");

			if(!Selected())
			{
				_renderer.material = _selectedMaterial;
			}

			selectors++;
		}

		public void Deselect()
		{
			if (!Selected()) { throw new Exception($"UID: {GetInstanceID()} | {name} | deselected with no selectors"); }

			selectors--;
			if (!Selected())
			{
				_renderer.material = _originalMaterial;
			}
			Debug.Log($"UID: {GetInstanceID()} | {name} | deselected");
		}
	}
}