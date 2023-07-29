using System.Collections;
using UnityEngine;

namespace Birdy.Things.Components
{
	public class CanAttack : MonoBehaviour
	{
		// Targets
		private bool bAttackGround;
		public bool IsAttackingGround { get { return bAttackGround; } }

		private Selection _target;
		public Selection Target
		{
			get { return _target; }
			set { bAttackGround = false; _target = value; _groundTarget = null; }
		}

		private World.Volume _groundTarget;
		public World.Volume GroundTarget
		{
			get { return _groundTarget; }
			set { bAttackGround = true; _groundTarget = value; _target = null; }
		}

		// Weapon(s)
		Inventory _inventory;


		// Use this for initialization
		void Start()
		{

		}

		// Update is called once per frame
		void Update()
		{

		}

		void UpdateWeapon()
		{
			
		}


	}
}