using System;
using System.Collections.Generic;
using UnityEngine;

namespace Birdy
{
    public class Unit : MonoBehaviour, IThing
    {
	    private float _health;
	    private float _maxHealth;
		private float _speed;

		public Vector3 PositionTarget { get; set; }

	    public float Health
	    {
		    get => _health;
			set => _health = value;
	    }

	    public void Damage(float amount)
		{
			_health = Mathf.Clamp(_health - amount, 0, _maxHealth);
		}

	    public void Heal(float amount)
		{
			_health = Mathf.Clamp(_health + amount, 0, _maxHealth);
		}
		
		private void Start()
		{
			PositionTarget = transform.position;
		}

		private void Update()
		{
			UpdatePosition();
		}


		// Todo: Move all of this to a pathfinder class once the map is more defined.
		private void UpdatePosition()
		{
			if (PositionTarget == transform.position) { return; }

			Vector3 deltaPos = (PositionTarget - transform.position);

			if (deltaPos.magnitude > _speed * Time.deltaTime)
			{
				Vector3 toMove = deltaPos.normalized * _speed * Time.deltaTime;
				transform.position = transform.position + toMove;
			}
			else
			{
				transform.position = PositionTarget;
			}
		}

		private void UseItem(Targetable target)
		{

		}
	}
}