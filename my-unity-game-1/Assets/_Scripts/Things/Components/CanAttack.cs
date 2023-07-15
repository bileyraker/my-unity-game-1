using System.Collections;
using UnityEngine;

namespace Birdy.Things.Components
{
	public class CanAttack : MonoBehaviour
	{
		// Targets
		private bool bAttackGround;

		private Selection _target;
		public Selection Target
		{
			get { return _target; }
			set { bAttackGround = false; _target = value; }
		}

		private Vector3 _groundTarget;
		public Vector3 GroundTarget
		{
			get { return _groundTarget; }
			set { bAttackGround = true; _groundTarget = value; }
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