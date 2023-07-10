using System;
using UnityEngine;

namespace Birdy.Things
{
    public interface IWeapon : IDurability
    {
		float BaseCooldown { get; set; }

		float BaseDamage { get; set; }

		float BaseAccuracy { get; set; }

		void Fire();
    }
}