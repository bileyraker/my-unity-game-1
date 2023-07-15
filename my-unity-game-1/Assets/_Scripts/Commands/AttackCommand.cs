﻿using System.Collections;
using UnityEngine;
using Birdy.Things.Components;

namespace Birdy.Commands
{
	public class AttackCommand : ICommand
	{
		private CanAttack _obj;
		private Selection _target;
		private Selection _prevTarget;

		public float TimeIssued { get; set; } = -1f;

		public AttackCommand(CanAttack obj, Selection target)
		{
			_obj = obj;
			_target = target;
		}

		public void Execute()
		{
			
		}

		public void Undo()
		{

		}
	}

}