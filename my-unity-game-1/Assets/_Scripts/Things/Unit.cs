using System;
using System.Collections.Generic;
using UnityEngine;

namespace Birdy
{
    public class Unit : Selectable
    {
	    public ThingRuntimeSet itemRS;

	    private float _health;
	    private float _maxHealth;

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
	}
}