using System;
using System.Collections.Generic;
using UnityEngine;

namespace Birdy.Things.Components
{
    public class Unit : MonoBehaviour, IThing
    {
		List<UnitTypes> _types;

		private int _team;
	    private float _health;
	    private float _maxHealth;

		public int Team { get { return _team; } }

		public void GiveToTeam(int team)
		{
			_team = team;
		}

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

		private void Awake()
		{
			_types = new List<UnitTypes>();
			_team = -1;
		}

		private void Start()
		{
		}

		private void Update()
		{
		}

		private void UseItem(IsTargetable target)
		{

		}
	}
}